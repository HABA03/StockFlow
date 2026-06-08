using MediatR;

namespace SF.Application.DTO.Employee.Create
{
    public class CreateEmployeeRequest : IRequest<CreateEmployeeResponse>
    {
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}