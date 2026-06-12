using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Employee.GetBy;
using SF.Domain.Interface;

namespace SF.Application.Handler.Employee
{
    public class GetEmployeeByHandler : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetEmployeeByIdRequest> _validation;

        public GetEmployeeByHandler(IEmployeeRepository employeeRepository, IMapper mapper, IValidator<GetEmployeeByIdRequest> validation)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _validation = validation;
        }

        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validation.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _employeeRepository.GetEmployeeBy(request.Id, cancellationToken);
            return _mapper.Map<GetEmployeeByIdResponse>(response);
        }
    }
}