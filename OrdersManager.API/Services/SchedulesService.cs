using AutoMapper;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Services;

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

        public bool Delete(Guid id)
        {
            var feedback = _repositoryManager.SchedulesRepository.GetById(id, trackChanges: false);

            if (feedback == null)
            {
                return false;
            }

            _repositoryManager.SchedulesRepository.Delete(feedback);
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
    }
}
