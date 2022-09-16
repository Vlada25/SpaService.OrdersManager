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

        public async Task<Feedback> Create(FeedbackForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Feedback>(entityForCreation);

            await _repositoryManager.FeedbacksRepository.Create(entity);

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.FeedbacksRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.FeedbacksRepository.Delete(entity);

            await _repositoryManager.Save();

            return true;
        }

        public async Task<IEnumerable<Feedback>> GetAll() =>
            await _repositoryManager.FeedbacksRepository.GetAll(trackChanges: false);

        public async Task<Feedback> GetById(Guid id) =>
            await _repositoryManager.FeedbacksRepository.GetById(id, trackChanges: false);

        public async Task<bool> Update(FeedbackForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.FeedbacksRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            await _repositoryManager.Save();

            return true;
        }
    }
}
