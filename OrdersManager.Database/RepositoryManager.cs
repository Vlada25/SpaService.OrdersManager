using OrdersManager.Database.Repositories;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database
{
    public class RepositoryManager : IRepositoryManager
    {
        private OrdersManagerDbContext _dbContext;

        private IOrdersRepository _ordersRepository;
        private IFeedbacksRepository _feedbacksRepository;

        public IOrdersRepository OrdersRepository
        {
            get
            {
                if (_ordersRepository == null)
                {
                    _ordersRepository = new OrdersRepository(_dbContext);
                }
                return _ordersRepository;
            }
        }

        public IFeedbacksRepository FeedbacksRepository
        {
            get
            {
                if (_feedbacksRepository == null)
                {
                    _feedbacksRepository = new FeedbacksRepository(_dbContext);
                }
                return _feedbacksRepository;
            }
        }


        public void Save() => _dbContext.SaveChanges();
    }
}
