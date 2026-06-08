using SF.Domain.Enum;

namespace SF.Application.DTO.Category.Get
{
    public class GetCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public CategoryStatusEnum Status { get; set; }
    }
}