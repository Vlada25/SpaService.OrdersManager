using OrdersManager.Database;
using OrdersManager.Database.Repositories;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Repositories
{
    public class FeedbacksRepository : BaseRepository<Feedback>, IFeedbacksRepository
    {
        public FeedbacksRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(Feedback entity) => CreateEntity(entity);

        public IEnumerable<Feedback> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges);

        public Feedback GetById(Guid id, bool trackChanges) =>
            GetByCondition(fm => fm.Id.Equals(id), trackChanges).SingleOrDefault();

        public void Delete(Feedback entity) => DeleteEntity(entity);
    }
}
}
