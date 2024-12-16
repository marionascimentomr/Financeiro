namespace Pay.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey> :  IDisposable
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> GetAll();
        TEntity? GetById(TKey id);
        TEntity? Get(Func<TEntity, bool> where);
        Task<TEntity?> GetByIdAsync(TKey id);
    }
}
