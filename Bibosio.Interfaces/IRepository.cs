namespace Bibosio.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<int> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(Guid id);
        Task<TEntity[]> GetAllAsync(int skip, int take);
        Task<TEntity?> GetByIdAsync(Guid id);
    }
}
