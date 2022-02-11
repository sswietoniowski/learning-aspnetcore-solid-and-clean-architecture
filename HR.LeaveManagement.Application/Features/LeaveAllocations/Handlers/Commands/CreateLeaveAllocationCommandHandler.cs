using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(
            IUnitOfWork unitOfWork,
            IEmailSender emailSender,
            IUserService userService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Falied";
                response.ValidationErrors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = await _unitOfWork.LeaveTypeRepository.Get(request.LeaveAllocationDto.LeaveTypeId);
                var employees = await _userService.GetEmployees();
                var period = DateTime.Now.Year;
                var alocations = new List<LeaveAllocation>();
                foreach (var employee in employees)
                {
                    if (await _unitOfWork.LeaveAllocationRepository.AllocationExists(employee.Id, leaveType.Id, period))
                    {
                        continue;
                    }

                    alocations.Add(new LeaveAllocation
                    {
                        EmployeeId = employee.Id,
                        LeaveTypeId = leaveType.Id,
                        NumberDays = leaveType.DefaultDays,
                        Period = period
                    });
                }

                await _unitOfWork.LeaveAllocationRepository.AddAllocations(alocations);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
            }

            return response;
        }
    }
}
