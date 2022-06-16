using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
        {
                public BrandReadRepository(ApplicationDbContext context) : base(context) { }
        }
}
