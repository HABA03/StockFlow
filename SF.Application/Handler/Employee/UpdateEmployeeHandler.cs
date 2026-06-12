using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Employee.Update;
using SF.Domain.Interface;

namespace SF.Application.Handler.Employee
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, UpdateEmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IValidator<UpdateEmployeeRequest> _validator;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository, IValidator<UpdateEmployeeRequest> validator, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _employeeRepository.UpdateEmployee(_mapper.Map<Domain.Entity.Employee>(request), cancellationToken);
            return new UpdateEmployeeResponse{ Response = response };
        }
    }
}