using FluentValidation;
using SF.Application.DTO.Product.Create;

namespace SF.Application.Validation.Product
{
    public class CreateProductRequestValidation : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .NotNull().WithMessage("Name cannot be null.");
            
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .NotNull().WithMessage("Description cannot be null.")
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.")
                .NotNull().WithMessage("Price cannot be null.")
                .NotEmpty().WithMessage("Price is required.");
            
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.")
                .NotNull().WithMessage("CategoryId cannot be null.")
                .NotEmpty().WithMessage("CategoryId is required.");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("SupplierId must be greater than 0.")   
                .NotNull().WithMessage("SupplierId cannot be null.")
                .NotEmpty().WithMessage("SupplierId is required.");
        }
    }
}