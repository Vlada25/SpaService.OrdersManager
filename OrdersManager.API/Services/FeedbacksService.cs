using AutoMapper;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Feedback;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Services;

namespace OrdersManager.API.Services
{
    public class FeedbacksService : IFeedbacksService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public FeedbacksService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public Feedback Create(FeedbackForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Feedback>(entityForCreation);

            _repositoryManager.FeedbacksRepository.Create(entity);
            _repositoryManager.Save();

            return entity;
        }

        public bool Delete(Guid id)
        {
            var entity = _repositoryManager.FeedbacksRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.FeedbacksRepository.Delete(entity);
            _repositoryManager.Save();

            return true;
        }

        public IEnumerable<Feedback> GetAll() =>
            _repositoryManager.FeedbacksRepository.GetAll(trackChanges: false);

        public Feedback GetById(Guid id) =>
            _repositoryManager.FeedbacksRepository.GetById(id, trackChanges: false);

        public bool Update(FeedbackForUpdateDto entityForUpdate)
        {
            var entity = _repositoryManager.FeedbacksRepository.GetById(entityForUpdate.Id, trackChanges: true);

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
