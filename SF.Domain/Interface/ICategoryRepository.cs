using SF.Domain.Entity;

namespace SF.Domain.Interface
{
    public interface ICategoryRepository
    {
        Task<string> CreateCategory(Category category, CancellationToken cancellationToken);
        Task<string> UpdateCategory(Category category, CancellationToken cancellationToken);
        Task<Category> GetCategoryBy(int id, CancellationToken cancellationToken);
        Task<List<Category>> GetCategories(CancellationToken cancellationToken);
    }
}