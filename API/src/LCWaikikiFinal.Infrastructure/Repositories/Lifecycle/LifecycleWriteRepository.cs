using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class LifecycleWriteRepository : WriteRepository<Lifecycle>, ILifecycleWriteRepository
        {
                public LifecycleWriteRepository(ApplicationDbContext context) : base(context) { }
        }
}
