using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Repositories
{
    public class SchedulesRepository : BaseRepository<Schedule>, ISchedulesRepository
    {
        public SchedulesRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(Schedule entity) => CreateEntity(entity);

        public IEnumerable<Schedule> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges);

        public Schedule GetById(Guid id, bool trackChanges) =>
            GetByCondition(fm => fm.Id.Equals(id), trackChanges).SingleOrDefault();

        public void Delete(Schedule entity) => DeleteEntity(entity);
    }
}
