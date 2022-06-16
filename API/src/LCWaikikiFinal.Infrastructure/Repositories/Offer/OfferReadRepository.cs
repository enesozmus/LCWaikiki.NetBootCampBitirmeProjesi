using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LCWaikikiFinal.Infrastructure.Repositories
{
        public class OfferReadRepository : ReadRepository<Offer>, IOfferReadRepository
        {
                private readonly ApplicationDbContext _context;

                public OfferReadRepository(ApplicationDbContext context) : base(context)
                {
                        _context = context;
                }

                public async Task<IReadOnlyList<Offer>> GetOffersByUser(Expression<Func<Offer, bool>> predicate)
                {
                        return await _context.Offers
                                        .Include(x => x.Product)
                                        .Where(predicate)
                                        .ToListAsync();
                }
        }
}