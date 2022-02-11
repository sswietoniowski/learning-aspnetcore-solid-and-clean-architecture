using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(
            IUnitOfWork unitOfWork,
            IEmailSender emailSender,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<BaseCommonResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommonResponse();
            var validator = new CreateLeaveRequestDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(q => q.Type == "uid")?.Value;

            var allocations = await _unitOfWork.LeaveAllocationRepository.GetUserAllocations(userId, request.LeaveRequestDto.LeaveTypeId);
            if (allocations is null)
            {
                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.LeaveRequestDto.LeaveTypeId),
                    "You do not have any allocations for this leave type"));
            }
            else
            {
                int daysRequested = (int)(request.LeaveRequestDto.EndDate - request.LeaveRequestDto.StartDate).TotalDays;

                if (daysRequested > allocations.NumberDays)
                {
                    validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.LeaveRequestDto.EndDate), "You do not have enough days for this request"));
                }
            }

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
                leaveRequest.RequestingEmployeeId = userId;
                leaveRequest = await _unitOfWork.LeaveRequestRepository.Add(leaveRequest);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = leaveRequest.Id;

                var emailAddress = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;

                var email = new Email
                {
                    To = emailAddress,
                    Subject = "Leave Request Submitted",
                    Body = $"Your leave request for {request.LeaveRequestDto.StartDate} to {request.LeaveRequestDto.EndDate}" +
                           $"has been submitted successfully."
                };
                try
                {
                    await _emailSender.SendEmail(email);
                }
                catch (Exception ex)
                {
                    // TODO: Log or handle error, but don't throw
                }
            }

            return response;
        }
    }
}
