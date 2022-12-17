using System.Linq.Expressions;

namespace AtturraTest.Interfaces
{
    public interface IAsyncRepository1<TEntity>
    {
        Task Add(TEntity entity);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);
        Task Remove(TEntity entity);
        Task Update(TEntity entity);
    }
}