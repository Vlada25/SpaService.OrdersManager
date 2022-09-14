using AutoMapper;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.LogMessages;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.API.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggingService _loggingService;

        public OrdersService(IRepositoryManager repositoryManager,
            ILoggingService loggingService,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggingService = loggingService;
            _mapper = mapper;
        }

        public async Task<Order> Create(OrderForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Order>(entityForCreation);

            _repositoryManager.OrdersRepository.Create(entity);
            _repositoryManager.Save();

            await _loggingService.SendLogMessage(entity, OrderAction.Created);

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = _repositoryManager.OrdersRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.OrdersRepository.Delete(entity);
            _repositoryManager.Save();

            await _loggingService.SendLogMessage(entity, OrderAction.Deleted);

            return true;
        }

        public bool DeleteByClientId(Guid clientId)
        {
            var entities = _repositoryManager.OrdersRepository.GetByClientId(clientId);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                _repositoryManager.OrdersRepository.Delete(entity);

                _loggingService.SendLogMessage(entity, OrderAction.Deleted);
            }

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

        public bool UpdateClient(ClientUpdated client)
        {
            var entities = _repositoryManager.OrdersRepository.GetByClientId(client.Id);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                entity.ClientName = client.Name;
                entity.ClientSurname = client.Surname;
            }

            _repositoryManager.Save();

            return true;
        }
    }
}
