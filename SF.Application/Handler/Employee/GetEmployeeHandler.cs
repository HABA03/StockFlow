using AutoMapper;
using MediatR;
using SF.Application.DTO.Employee.Get;
using SF.Domain.Interface;

namespace SF.Application.Handler.Employee
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeRequest, List<GetEmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetEmployeeResponse>> Handle(GetEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employeeInfo = await _employeeRepository.GetEmployees(cancellationToken);

            if(employeeInfo == null)
                throw new Exception("Error getting information");

            return _mapper.Map<List<GetEmployeeResponse>>(employeeInfo);
        }
    }
}