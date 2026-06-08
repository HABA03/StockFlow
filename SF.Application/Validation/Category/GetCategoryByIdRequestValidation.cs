using FluentValidation;
using SF.Application.DTO.Category.GetBy;

namespace SF.Application.Validation.Category
{
    public class GetCategoryByIdRequestValidation : AbstractValidator<GetCategoryByIdRequest>
    {
        public GetCategoryByIdRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}