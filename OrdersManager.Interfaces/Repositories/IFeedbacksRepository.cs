using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Interfaces.Repositories
{
    public interface IFeedbacksRepository
    {
        IEnumerable<Feedback> GetAll(bool trackChanges);
        Feedback GetById(Guid id, bool trackChanges);
        void Create(Feedback entity);
        void Delete(Feedback entity);
    }
}
