using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entity;
using SF.Domain.Interface;
using SF.Infrastructure.Context;

namespace SF.Infrastructure.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SFContext _context;

        public CategoryRepository(SFContext context)
        {
            _context = context;
        }

        public async Task<string> CreateCategory(Category category, CancellationToken cancellationToken)
        {
            if(category == null)
                throw new Exception("Category is null");

            category.CreatedDate = DateTime.UtcNow;
            category.Status = Domain.Enum.CategoryStatusEnum.Active;
            await _context.Category.AddAsync(category, cancellationToken);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Category created" : "Error creating new category";
        }

        public async Task<List<Category>> GetCategories(CancellationToken cancellationToken)
        {
            return await _context.Category.Where(c => c.Status != Domain.Enum.CategoryStatusEnum.Deleted).ToListAsync(cancellationToken);
        }

        public async Task<Category> GetCategoryBy(int id, CancellationToken cancellationToken)
        {
            return await _context.Category.FirstOrDefaultAsync(c => c.Id == id, cancellationToken)?? new Category();
        }

        public async Task<string> UpdateCategory(Category category, CancellationToken cancellationToken)
        {
            if(category == null)
                throw new Exception("Category is null");

            _context.Category.Update(category);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Category updated" : "Error updating category";
        }
    }
}