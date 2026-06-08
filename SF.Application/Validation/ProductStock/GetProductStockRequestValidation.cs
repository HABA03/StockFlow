using FluentValidation;
using SF.Application.DTO.ProductStock.GetBy;

namespace SF.Application.Validation.ProductStock
{
    public class GetProductStockRequestValidation : AbstractValidator<GetProductStockByIdRequest>
    {
        public GetProductStockRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.")
                .NotNull().WithMessage("ProductId cannot be null.")
                .NotEmpty().WithMessage("ProductId is required.");
        }
    }
}