using FluentValidation;
using SF.Application.DTO.Employee.Create;

namespace SF.Application.Validation.Employee
{
    public class CreateEmployeeRequestValidation : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeRequestValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.")
                .NotNull().WithMessage("First name cannot be null.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.")
                .NotNull().WithMessage("Last name cannot be null.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.")
                .NotNull().WithMessage("Phone number cannot be null.");
        }
    }
}