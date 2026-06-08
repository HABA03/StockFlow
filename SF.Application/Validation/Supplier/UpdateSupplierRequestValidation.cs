using FluentValidation;
using SF.Supplier.DTO.Supplier.Update;

namespace SF.Application.Validation.Supplier
{
    public class UpdateSupplierRequestValidation : AbstractValidator<UpdateSupplierRequest>
    {
        public UpdateSupplierRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");

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