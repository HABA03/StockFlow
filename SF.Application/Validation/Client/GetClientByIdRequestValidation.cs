using FluentValidation;
using SF.Application.DTO.Client.GetBy;

namespace SF.Application.Validation.Client
{
    public class GetClientByIdRequestValidation : AbstractValidator<GetClientByIdRequest>
    {
        public GetClientByIdRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}