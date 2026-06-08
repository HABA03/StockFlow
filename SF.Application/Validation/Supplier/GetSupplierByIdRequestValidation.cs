using FluentValidation;
using SF.Supplier.DTO.Supplier.GetBy;

namespace SF.Application.Validation.Supplier
{
    public class GetSupplierByIdRequestValidation : AbstractValidator<GetSupplierByIdRequest>
    {
        public GetSupplierByIdRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}