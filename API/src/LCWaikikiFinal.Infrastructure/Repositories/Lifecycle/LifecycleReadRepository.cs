using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class LifecycleReadRepository : ReadRepository<Lifecycle>, ILifecycleReadRepository
        {
                public LifecycleReadRepository(ApplicationDbContext context) : base(context) { }
        }
}
