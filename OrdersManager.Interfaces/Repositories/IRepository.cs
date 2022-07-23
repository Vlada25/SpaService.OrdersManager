using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAllEntities(bool trackChanges);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void CreateEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
    }
}
