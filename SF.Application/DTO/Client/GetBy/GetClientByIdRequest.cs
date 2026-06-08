using MediatR;

namespace SF.Application.DTO.Client.GetBy
{
    public class GetClientByIdRequest : IRequest<GetClientByIdResponse>
    {
        public int Id { get; set; }
    }
}