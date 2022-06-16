using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
        {
                private readonly ApplicationDbContext _context;
                public CategoryReadRepository(ApplicationDbContext context) : base(context)
                {
                        _context = context;
                }

                public async Task<IReadOnlyList<Category>> GetCategoriesWithProducts(int? id)
                {
                        return (IReadOnlyList<Category>)(await _context.Categories
                                        .Include(x => x.Products)
                                        .SingleOrDefaultAsync(x => x.Id == id) ?? new Category());

                        //return await _context.Categories
                        //        .Include(x => x.Products)
                        //        .SingleOrDefaultAsync(x => x.Id == id);
                }

                public async Task<IReadOnlyList<Category>> GetCategoriesWithProducts()
                {
                        return await _context.Categories
                                        .Include(x => x.Products)
                                        .ToListAsync();

                        //return await _context.Categories
                        //        .Include(x => x.Products)
                        //        .SingleOrDefaultAsync(x => x.Id == id);
                }
        }
}
