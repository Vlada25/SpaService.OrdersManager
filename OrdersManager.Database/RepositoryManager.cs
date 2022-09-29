using OrdersManager.Database.Repositories;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Repositories;

namespace OrdersManager.Database
{
    public class RepositoryManager : IRepositoryManager
    {
        private OrdersManagerDbContext _dbContext;

        private IOrdersRepository _ordersRepository;
        private IFeedbacksRepository _feedbacksRepository;
        private ISchedulesRepository _schedulesRepository;

        public RepositoryManager(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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

        public ISchedulesRepository SchedulesRepository
        {
            get
            {
                if (_schedulesRepository == null)
                {
                    _schedulesRepository = new SchedulesRepository(_dbContext);
                }
                return _schedulesRepository;
            }
        }

        public async Task Save() => await _dbContext.SaveChangesAsync();
    }
}
