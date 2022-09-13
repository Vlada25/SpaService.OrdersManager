using System.Linq.Expressions;

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
