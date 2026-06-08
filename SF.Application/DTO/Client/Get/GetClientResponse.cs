using SF.Domain.Enum;

namespace SF.Application.DTO.Client.Get
{
    public class GetClientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public ClientStatusEnum Status { get; set; }
    }
}