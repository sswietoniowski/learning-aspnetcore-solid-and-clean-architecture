﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(
            IUnitOfWork unitOfWork,
            IEmailSender emailSender,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var leaveAllocation =
                await _unitOfWork.LeaveAllocationRepository.Get(request.LeaveAllocationDto.Id);

            if (leaveAllocation is null)
            {
                throw new NotFoundException(nameof(leaveAllocation), request.LeaveAllocationDto.Id);
            }

            _mapper.Map(request.LeaveAllocationDto, leaveAllocation);
            await _unitOfWork.LeaveAllocationRepository.Update(leaveAllocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
