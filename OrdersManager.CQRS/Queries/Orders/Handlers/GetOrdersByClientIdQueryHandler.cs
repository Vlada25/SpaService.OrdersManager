using AutoMapper;
using MediatR;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Orders.Handlers
{
    public class GetOrdersByClientIdQueryHandler : IRequestHandler<GetOrdersByClientIdQuery, IEnumerable<OrderDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOrdersByClientIdQueryHandler(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByClientIdQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<OrderDto>>(
                await _repositoryManager.OrdersRepository.GetByClientId(request.ClientId, cancellationToken));
    }
}
