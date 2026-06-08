using SF.Domain.Enum;

namespace SF.Application.DTO.Employee.GetBy
{
    public class GetEmployeeByIdResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public ClientStatusEnum Status { get; set; }
    }
}