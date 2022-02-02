using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        public UpdateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            Include(new ILeaveAllocationDtoValidator(leaveAllocationRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
