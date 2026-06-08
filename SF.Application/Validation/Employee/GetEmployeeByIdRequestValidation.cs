using FluentValidation;
using SF.Application.DTO.Employee.GetBy;

namespace SF.Application.Validation.Employee
{
    public class GetEmployeeByIdRequestValidation : AbstractValidator<GetEmployeeByIdRequest>
    {
        public GetEmployeeByIdRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .NotNull().WithMessage("Id cannot be null.")
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}