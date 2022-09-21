using AutoMapper;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Person;
using SpaService.Domain.Messages.Service;

namespace OrdersManager.API.Services
{
    public class SchedulesService : ISchedulesService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SchedulesService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Schedule> Create(ScheduleForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Schedule>(entityForCreation);

            await _repositoryManager.SchedulesRepository.Create(entity);
            await _repositoryManager.Save();

            return entity;
        }

        public async Task<bool> DeleteByMasterId(Guid masterId)
        {
            var entities = await _repositoryManager.SchedulesRepository.GetByMasterId(masterId);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                _repositoryManager.SchedulesRepository.Delete(entity);
            }

            await _repositoryManager.Save();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.SchedulesRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.SchedulesRepository.Delete(entity);
            await _repositoryManager.Save();

            return true;
        }

        public async Task<IEnumerable<Schedule>> GetAll() =>
            await _repositoryManager.SchedulesRepository.GetAll(trackChanges: false);

        public async Task<Schedule> GetById(Guid id) =>
            await _repositoryManager.SchedulesRepository.GetById(id, trackChanges: false);

        public async Task<bool> Update(Guid id, ScheduleForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.SchedulesRepository.GetById(id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            _repositoryManager.SchedulesRepository.Update(entity);
            await _repositoryManager.Save();

            return true;
        }

        public async Task<bool> UpdateMaster(MasterUpdated master)
        {
            var entities = await _repositoryManager.SchedulesRepository.GetByMasterId(master.Id);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                entity.MasterName = master.Name;
                entity.MasterSurname = master.Surname;

                _repositoryManager.SchedulesRepository.Update(entity);
            }

            await _repositoryManager.Save();

            return true;
        }

        public async Task<bool> DeleteByServiceId(Guid serviceId)
        {
            var entities = await _repositoryManager.SchedulesRepository.GetByServiceId(serviceId);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                _repositoryManager.SchedulesRepository.Delete(entity);
            }

            await _repositoryManager.Save();

            return true;
        }

        public async Task<IEnumerable<Schedule>> GetByServiceId(Guid serviceId) =>
            await _repositoryManager.SchedulesRepository.GetByServiceId(serviceId);

        public async Task<bool> UpdateService(ServiceUpdated service)
        {
            var schedules = await _repositoryManager.SchedulesRepository.GetByServiceId(service.Id);

            foreach (var schedule in schedules)
            {
                schedule.Address = service.Address;
                schedule.ServiceName = service.Name;
                schedule.ServicePrice = service.Price;

                _repositoryManager.SchedulesRepository.Update(schedule);
            }
            
            await _repositoryManager.Save();

            return true;
        }

        public async Task<bool> UpdateSchedules(IEnumerable<Schedule> entities)
        {
            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                _repositoryManager.SchedulesRepository.Update(entity);
            }

            await _repositoryManager.Save();

            return true;
        }
    }
}
