using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class SizeWriteRepository : WriteRepository<Size>, ISizeWriteRepository
        {
                public SizeWriteRepository(ApplicationDbContext context) : base(context) { }
        }
}
