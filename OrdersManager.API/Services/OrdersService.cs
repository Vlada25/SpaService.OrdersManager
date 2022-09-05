using AutoMapper;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Services;

namespace OrdersManager.API.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrdersService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public Order Create(OrderForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Order>(entityForCreation);

            _repositoryManager.OrdersRepository.Create(entity);
            _repositoryManager.Save();

            return entity;
        }

        public bool Delete(Guid id)
        {
            var entity = _repositoryManager.OrdersRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.OrdersRepository.Delete(entity);
            _repositoryManager.Save();

            return true;
        }

        public IEnumerable<Order> GetAll() =>
            _repositoryManager.OrdersRepository.GetAll(trackChanges: false);

        public Order GetById(Guid id) =>
            _repositoryManager.OrdersRepository.GetById(id, trackChanges: false);

        public bool Update(OrderForUpdateDto entityForUpdate)
        {
            var entity = _repositoryManager.OrdersRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);
            _repositoryManager.Save();

            return true;
        }
    }
}
