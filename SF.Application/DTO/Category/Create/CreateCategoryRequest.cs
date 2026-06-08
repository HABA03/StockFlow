using MediatR;

namespace SF.Application.DTO.Category.Create
{
    public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}