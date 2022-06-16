using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class ColorReadRepository : ReadRepository<Color>, IColorReadRepository
        {
                public ColorReadRepository(ApplicationDbContext context) : base(context) { }
        }
}
