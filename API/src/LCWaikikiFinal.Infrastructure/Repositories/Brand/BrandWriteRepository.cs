using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
        {
                public BrandWriteRepository(ApplicationDbContext context) : base(context) { }
        }
}
