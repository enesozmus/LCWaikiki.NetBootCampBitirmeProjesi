using LCWaikikiFinal.Domain.Entities;
using System.Linq.Expressions;

namespace LCWaikikiFinal.Application.IRepositories
{
        public interface IProductReadRepository : IReadRepository<Product>
        {
                Task<IReadOnlyList<Product>> GetAllProductsForIndex();
                Task<Product> GetProductForDetail(int id);
                Task<IReadOnlyList<Product>> GetProductsByCategory(Expression<Func<Product, bool>> predicate);
        }
}
