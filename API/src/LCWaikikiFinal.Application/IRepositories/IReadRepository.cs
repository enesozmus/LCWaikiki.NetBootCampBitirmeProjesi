using LCWaikikiFinal.Domain.Entities;
using System.Linq.Expressions;

namespace LCWaikikiFinal.Application.IRepositories
{
        public interface IReadRepository<T> : IRepository<T> where T : EntityBase
        {
                #region Select

                Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
                Task<IReadOnlyList<T>> GetAllAsync();
                Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null);
                Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
                Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                string includeString = null,
                                                bool disableTracking = true);
                Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                               List<Expression<Func<T, object>>> includes = null,
                                               bool disableTracking = true);
                Task<T> GetByIdAsync(int id);

                Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids);
                Task<int> CountAsync();
                Task<int> CountAsync(Expression<Func<T, bool>> predicate);

                #endregion
        }
}
