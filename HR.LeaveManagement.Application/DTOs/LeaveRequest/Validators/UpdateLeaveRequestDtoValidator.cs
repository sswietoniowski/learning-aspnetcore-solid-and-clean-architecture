using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            Include(new ILeaveRequestDtoValidator(leaveRequestRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
