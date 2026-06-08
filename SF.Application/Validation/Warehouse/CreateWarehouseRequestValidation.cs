using FluentValidation;
using SF.Application.DTO.Warehouse.Create;

namespace SF.Application.Validation.Warehouse
{
    public class CreateWarehouseRequestValidation : AbstractValidator<CreateWarehouseRequest>
    {
        public CreateWarehouseRequestValidation()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name cannot be null.")
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Location)
                .NotNull().WithMessage("Location cannot be null.")
                .NotEmpty().WithMessage("Location is required.");

            RuleFor(x => x.ManagerName)
                .NotNull().WithMessage("ManagerName cannot be null.")
                .NotEmpty().WithMessage("ManagerName is required.");

            RuleFor(x => x.ContactPhone)
                .NotNull().WithMessage("ContactPhone cannot be null.")
                .NotEmpty().WithMessage("ContactPhone is required.")
                .MaximumLength(20).WithMessage("ContactPhone cannot exceed 20 characters.");
        }
    }
}