using MediatR;

namespace SF.Application.DTO.Category.GetBy
{
    public class GetCategoryByIdRequest : IRequest<GetCategoryByIdResponse>
    {
        public int Id { get; set; }
    }
}