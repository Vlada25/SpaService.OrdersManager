using OrdersManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Interfaces
{
    public interface IRepositoryManager
    {
        IOrdersRepository OrdersRepository { get; }
        IFeedbacksRepository FeedbacksRepository { get; }
        ISchedulesRepository SchedulesRepository { get; }

        void Save();
    }
}
