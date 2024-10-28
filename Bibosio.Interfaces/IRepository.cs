namespace Bibosio.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<int> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(Guid id);
        Task<TEntity[]> GetAllAsync(int skip = AppConst.SKIP, int take = 100);
        Task<TEntity?> GetByIdAsync(Guid id);
    }
}
