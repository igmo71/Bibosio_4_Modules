using System.Collections.Immutable;

namespace Bibosio.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<int> CreateAsync(TEntity entity);
        Task UpdateAsync(Guid id, TEntity entity);
        Task DeleteAsync(Guid id);
        ImmutableList<TEntity> GetAll(int skip, int take);
        Task<TEntity> GetByIdAsync(Guid id);
    }
}
