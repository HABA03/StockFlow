using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Employee.Create;
using SF.Domain.Interface;

namespace SF.Application.Handler.Employee
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateEmployeeRequest> _validator;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper, IValidator<CreateEmployeeRequest> validator)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _employeeRepository.CreateEmployee(_mapper.Map<Domain.Entity.Employee>(request), cancellationToken);
            return new CreateEmployeeResponse{ Response = response };
        }
    }
}