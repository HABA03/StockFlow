using FluentValidation;
using SF.Application.DTO.Product.GetBy;

namespace SF.Application.Validation.Product
{
    public class GetProductByIdRequestValidation : AbstractValidator<GetProductByIdRequest>
    {
        public GetProductByIdRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}