using FluentValidation;
using SF.Application.DTO.ProductStock.Update;

namespace SF.Application.Validation.ProductStock
{
    public class UpdateProductStockRequestValidation : AbstractValidator<UpdateProductStockRequest>
    {
        public UpdateProductStockRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0.")
                .NotNull().WithMessage("Quantity cannot be null.")
                .NotEmpty().WithMessage("Quantity is required.");
        }
    }
}