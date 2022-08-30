using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Interfaces.Repositories
{
    public interface ISchedulesRepository
    {
        IEnumerable<Schedule> GetAll(bool trackChanges);
        Schedule GetById(Guid id, bool trackChanges);
        void Create(Schedule entity);
        void Delete(Schedule entity);
    }
}
