using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class OfferWriteRepository : WriteRepository<Offer>, IOfferWriteRepository
        {
                public OfferWriteRepository(ApplicationDbContext context) : base(context) { }
        }
}
