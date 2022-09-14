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

        public Schedule Create(ScheduleForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Schedule>(entityForCreation);

            _repositoryManager.SchedulesRepository.Create(entity);
            _repositoryManager.Save();

            return entity;
        }

        public bool DeleteByMasterId(Guid masterId)
        {
            var entities = _repositoryManager.SchedulesRepository.GetByMasterId(masterId);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                _repositoryManager.SchedulesRepository.Delete(entity);
            }

            _repositoryManager.Save();

            return true;
        }

        public bool Delete(Guid id)
        {
            var entity = _repositoryManager.SchedulesRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.SchedulesRepository.Delete(entity);
            _repositoryManager.Save();

            return true;
        }

        public IEnumerable<Schedule> GetAll() =>
            _repositoryManager.SchedulesRepository.GetAll(trackChanges: false);

        public Schedule GetById(Guid id) =>
            _repositoryManager.SchedulesRepository.GetById(id, trackChanges: false);

        public bool Update(ScheduleForUpdateDto entityForUpdate)
        {
            var entity = _repositoryManager.SchedulesRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);
            _repositoryManager.Save();

            return true;
        }

        public bool UpdateMaster(MasterUpdated master)
        {
            var entities = _repositoryManager.SchedulesRepository.GetByMasterId(master.Id);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                entity.MasterName = master.Name;
                entity.MasterSurname = master.Surname;
            }

            _repositoryManager.Save();

            return true;
        }

        public bool DeleteByServiceId(Guid serviceId)
        {
            var entities = _repositoryManager.SchedulesRepository.GetByServiceId(serviceId);

            if (entities == null)
            {
                return false;
            }

            foreach (var entity in entities)
            {
                _repositoryManager.SchedulesRepository.Delete(entity);
            }

            _repositoryManager.Save();

            return true;
        }

        public IEnumerable<Schedule> GetByServiceId(Guid serviceId) =>
            _repositoryManager.SchedulesRepository.GetByServiceId(serviceId);

        public bool UpdateService(ServiceUpdated service)
        {
            var schedules = _repositoryManager.SchedulesRepository.GetByServiceId(service.Id);

            if (schedules == null)
            {
                return false;
            }

            if (service.Address == null)
            {
                foreach (var schedule in schedules)
                {
                    schedule.ServiceName = service.Name;
                }
            }
            else if (service.Name == null)
            {
                foreach (var schedule in schedules)
                {
                    schedule.Address = service.Address;
                }
            }
            else
            {
                foreach (var schedule in schedules)
                {
                    schedule.Address = service.Address;
                    schedule.ServiceName = service.Name;
                    schedule.ServicePrice = service.Price;
                }
            }

            return true;
        }
    }
}
