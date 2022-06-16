using LCWaikikiFinal.Domain.Entities;

namespace LCWaikikiFinal.Application.IRepositories
{
        public interface IRepository<T> where T : EntityBase
        {
                IQueryable<T> Table { get; }
                IQueryable<T> TableNoTracking { get; }
        }
}
