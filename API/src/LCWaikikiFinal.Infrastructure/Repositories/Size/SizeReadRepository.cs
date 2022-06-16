using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class SizeReadRepository : ReadRepository<Size>, ISizeReadRepository
        {
                public SizeReadRepository(ApplicationDbContext context) : base(context) { }
        }
}
