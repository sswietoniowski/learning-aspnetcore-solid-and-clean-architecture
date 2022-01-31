using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public CreateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;

            RuleFor(p => p.NumberDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveAllocationRepository.Exists(id);
                    return !leaveTypeExists;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.Period)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }
    }
}
