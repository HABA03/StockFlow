using FluentValidation;
using SF.Application.DTO.Client.Create;

namespace SF.Application.Validation.Client
{
    public class CreateClientRequestValidation : AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .NotNull().WithMessage("Name cannot be null.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(100).WithMessage("LastName cannot exceed 100 characters.")
                .NotNull().WithMessage("LastName cannot be null.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required.")
                .MaximumLength(20).WithMessage("PhoneNumber cannot exceed 20 characters.")
                .NotNull().WithMessage("PhoneNumber cannot be null.");
        }
    }
}