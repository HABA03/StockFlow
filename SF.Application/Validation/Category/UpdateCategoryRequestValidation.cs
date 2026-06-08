using FluentValidation;
using SF.Application.DTO.Category.Update;

namespace SF.Application.Validation.Category
{
    public class UpdateCategoryRequestValidation : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .NotNull().WithMessage("Name cannot be null.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .NotNull().WithMessage("Description cannot be null.")
                .NotEmpty().WithMessage("Description is required.");
        }
    }
}