using AutoMapper;
using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;
using OrdersManager.Interfaces.Services;
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

        public async Task<OrderDto> Create(OrderForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Order>(entityForCreation);

            await _repositoryManager.OrdersRepository.Create(entity);

            await _loggingService.SendCreatedMessage(entity);

            return _mapper.Map<OrderDto>(entity);
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

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var entities = await _repositoryManager.OrdersRepository.GetAll(trackChanges: false);
            return _mapper.Map<IEnumerable<OrderDto>>(entities);
        }
            

        public async Task<IEnumerable<OrderDto>> GetByClientId(Guid clientId)
        {
            var entities = await _repositoryManager.OrdersRepository.GetByClientId(clientId);
            return _mapper.Map<IEnumerable<OrderDto>>(entities);
        }
            

        public async Task<OrderDto> GetById(Guid id)
        {
            var entity = await _repositoryManager.OrdersRepository.GetById(id, trackChanges: false);
            return _mapper.Map<OrderDto>(entity);
        }

        public async Task<OrderDto> GetByScheduleId(Guid scheduleId)
        {
            var entity = await _repositoryManager.OrdersRepository.GetByScheduleId(scheduleId);
            return _mapper.Map<OrderDto>(entity);
        }

        public async Task<bool> Update(Guid id, OrderForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.OrdersRepository.GetById(id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            _repositoryManager.OrdersRepository.Update(entity);
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

                _repositoryManager.OrdersRepository.Update(entity);
            }

            await _repositoryManager.Save();

            return true;
        }

        public async Task<bool> UpdateOrders(IEnumerable<Order> entities)
        {
            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                _repositoryManager.OrdersRepository.Update(entity);
            }

            await _repositoryManager.Save();

            foreach (Order entity in entities)
            {
                await _loggingService.SendUpdatedMessage(entity);
            }

            return true;
        }
    }
}
