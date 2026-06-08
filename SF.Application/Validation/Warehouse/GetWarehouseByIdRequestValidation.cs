using FluentValidation;
using SF.Application.DTO.Warehouse.GetBy;

namespace SF.Application.Validation.Warehouse
{
    public class GetWarehouseByIdRequestValidation : AbstractValidator<GetWarehouseByIdRequest>
    {
        public GetWarehouseByIdRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}