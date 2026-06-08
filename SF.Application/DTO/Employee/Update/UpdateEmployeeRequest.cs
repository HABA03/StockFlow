using MediatR;

namespace SF.Application.DTO.Employee.Update
{
    public class UpdateEmployeeRequest : IRequest<UpdateEmployeeResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}