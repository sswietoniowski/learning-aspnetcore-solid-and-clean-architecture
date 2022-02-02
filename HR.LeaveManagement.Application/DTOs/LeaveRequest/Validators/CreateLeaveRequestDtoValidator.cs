using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            Include(new ILeaveRequestDtoValidator(leaveRequestRepository));
        }
    }
}
