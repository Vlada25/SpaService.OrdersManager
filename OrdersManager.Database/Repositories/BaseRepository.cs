using Microsoft.EntityFrameworkCore;
using OrdersManager.Interfaces.Repositories;
using System.Linq.Expressions;

namespace OrdersManager.Database.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected OrdersManagerDbContext dbContext;

        public BaseRepository(OrdersManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateEntity(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void DeleteEntity(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAllEntities(bool trackChanges)
        {
            return !trackChanges ? dbContext.Set<T>().AsNoTracking() : dbContext.Set<T>();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                dbContext.Set<T>().Where(expression).AsNoTracking() :
                dbContext.Set<T>().Where(expression);
        }

        public void UpdateEntity(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}
