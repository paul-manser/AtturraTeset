using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AtturraTest.Interfaces
{

    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        
        TEntity GetById(object primaryKey);

        void Save(TEntity entity); // should handle both new and updating entities

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetWhere(Expression<Func<IEntity, bool>> predicate);

    }
}
