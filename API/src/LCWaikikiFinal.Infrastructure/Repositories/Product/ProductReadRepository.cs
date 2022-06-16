using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
        {
                private readonly ApplicationDbContext _context;

                public ProductReadRepository(ApplicationDbContext context) : base(context)
                {
                        _context = context;
                }

                public async Task<IReadOnlyList<Product>> GetAllProductsForIndex()
                {
                        return await _context.Products
                                .Include(x => x.AppUser)
                                .Include(x => x.Brand)
                                .Include(x => x.Color)
                                .Include(x => x.Size)
                                .Include(x => x.Lifecycle)
                                .ToListAsync();
                }

                public async Task<Product> GetProductForDetail(int id)
                {
                        return await _context.Products
                                .Include(x => x.AppUser)
                                .Include(x => x.Brand)
                                .Include(x => x.Color)
                                 .Include(x => x.Size)
                                .Include(x => x.Lifecycle)
                                .Include(x => x.ProductDetail)
                                .FirstOrDefaultAsync(x => x.Id == id) ?? new Product();
                }

                public async Task<IReadOnlyList<Product>> GetProductsByCategory(Expression<Func<Product, bool>> predicate)
                {
                        return await _context.Products
                                  .Include(x => x.AppUser)
                                  .Include(x => x.Brand)
                                  .Include(x => x.Color)
                                  .Include(x => x.Size)
                                  .Include(x => x.Lifecycle)
                                  .Where(predicate)
                                  .ToListAsync();
                }
        }
}
