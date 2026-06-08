using FluentValidation;
using SF.Supplier.DTO.Supplier.Create;

namespace SF.Application.Validation.Supplier
{
    public class CreateSupplierRequestValidation : AbstractValidator<CreateSupplierRequest>
    {
        public CreateSupplierRequestValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .NotNull().WithMessage("Name cannot be null.");

            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(x => x.ContactPhone)
                .NotEmpty().WithMessage("PhoneNumber is required.")
                .MaximumLength(20).WithMessage("PhoneNumber cannot exceed 20 characters.")
                .NotNull().WithMessage("PhoneNumber cannot be null.");
        }
    }
}