using LCWaikikiFinal.Domain.Entities;
using System.Linq.Expressions;

namespace LCWaikikiFinal.Application.IRepositories
{
        public interface IOfferReadRepository : IReadRepository<Offer>
        {
                public Task<IReadOnlyList<Offer>> GetOffersByUser(Expression<Func<Offer, bool>> predicate);
        }
}
