using MediatR;

namespace SF.Application.DTO.Client.Create
{
    public class CreateClientRequest : IRequest<CreateClientResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}