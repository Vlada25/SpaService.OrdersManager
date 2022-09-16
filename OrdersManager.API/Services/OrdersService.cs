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

            await _repositoryManager.OrdersRepository.Create(entity);

            await _loggingService.SendCreatedMessage(entity);

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.OrdersRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.OrdersRepository.Delete(entity);

            await _loggingService.SendDeletedMessage(entity);

            await _repositoryManager.Save();

            return true;
        }

        public async Task<bool> DeleteByClientId(Guid clientId)
        {
            var entities = await _repositoryManager.OrdersRepository.GetByClientId(clientId);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                _repositoryManager.OrdersRepository.Delete(entity);

                await _loggingService.SendDeletedMessage(entity);
            }

            await _repositoryManager.Save();

            return true;
        }

        public async Task<IEnumerable<Order>> GetAll() =>
            await _repositoryManager.OrdersRepository.GetAll(trackChanges: false);

        public async Task<Order> GetById(Guid id) =>
            await _repositoryManager.OrdersRepository.GetById(id, trackChanges: false);

        public async Task<bool> Update(OrderForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.OrdersRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            await _repositoryManager.Save();

            await _loggingService.SendUpdatedMessage(entity);

            return true;
        }

        public async Task<bool> UpdateClient(ClientUpdated client)
        {
            var entities = await _repositoryManager.OrdersRepository.GetByClientId(client.Id);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                entity.ClientName = client.Name;
                entity.ClientSurname = client.Surname;
            }

            await _repositoryManager.Save();

            return true;
        }
    }
}
