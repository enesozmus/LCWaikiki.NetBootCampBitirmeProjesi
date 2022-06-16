using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
        {
                public ProductWriteRepository(ApplicationDbContext context) : base(context) { }
        }
}
