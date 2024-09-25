namespace Bibosio.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<int> CreateAsync(TEntity entity);
        Task UpdateAsync(Guid id, TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
