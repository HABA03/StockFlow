using FluentValidation;
using SF.Application.DTO.Warehouse.Update;

namespace SF.Application.Validation.Warehouse
{
    public class UpdateWarehouseRequestValidation : AbstractValidator<UpdateWarehouseRequest>
    {
        public UpdateWarehouseRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");

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