using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
        {
                public CategoryWriteRepository(ApplicationDbContext context) : base(context) { }
        }
}
