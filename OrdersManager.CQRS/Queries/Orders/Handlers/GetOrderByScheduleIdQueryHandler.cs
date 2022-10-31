using AutoMapper;
using MediatR;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Orders.Handlers
{
    public class GetOrderByScheduleIdQueryHandler : IRequestHandler<GetOrderByScheduleIdQuery, OrderDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOrderByScheduleIdQueryHandler(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByScheduleIdQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<OrderDto>(
                await _repositoryManager.OrdersRepository.GetByScheduleId(request.ScheduleId, cancellationToken));
    }
}
