using FluentValidation;
using SF.Application.DTO.ProductStock.Create;

namespace SF.Application.Validation.ProductStock
{
    public class CreateProductStockRequestValidation : AbstractValidator<CreateProductStockRequest>
    {
        public CreateProductStockRequestValidation()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.")
                .NotNull().WithMessage("ProductId cannot be null.")
                .NotEmpty().WithMessage("ProductId is required.");

            RuleFor(x => x.WarehouseId)
                .GreaterThan(0).WithMessage("WarehouseId must be greater than 0.")
                .NotNull().WithMessage("WarehouseId cannot be null.")
                .NotEmpty().WithMessage("WarehouseId is required.");   

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0.")
                .NotNull().WithMessage("Quantity cannot be null.")
                .NotEmpty().WithMessage("Quantity is required.");
        }
    }
}