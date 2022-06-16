using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class ColorWriteRepository : WriteRepository<Color>, IColorWriteRepository
        {
                public ColorWriteRepository(ApplicationDbContext context) : base(context) { }
        }
}
