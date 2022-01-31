using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must exceed {ComparisonValue} characters.");

            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .LessThan(100);
        }
    }
}
