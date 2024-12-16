using Pay.Domain.Interfaces.Repositories;
using Pay.Infra.Data.Contexts;

namespace Pay.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly DataContext? _dataContext;

        protected BaseRepository(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(TEntity entity)
        {
            _dataContext?.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dataContext?.Update(entity);
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dataContext?.Set<TEntity>().Update(entity);
            await _dataContext.SaveChangesAsync();
        }
        public virtual void Delete(TEntity entity)
        {
            _dataContext?.Remove(entity);
        }
        public virtual List<TEntity>? GetAll()
        {
            return _dataContext?.Set<TEntity>().ToList();
        }
        public virtual TEntity? GetById(TKey id)
        {
            return _dataContext?.Set<TEntity>().Find(id);
        }
        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public virtual TEntity? Get(Func<TEntity, bool> where)
        {
            return _dataContext?.Set<TEntity>().FirstOrDefault(where);
        }
        public virtual void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
