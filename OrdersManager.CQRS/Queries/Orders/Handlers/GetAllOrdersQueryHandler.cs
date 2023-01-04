using AutoMapper;
using MediatR;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Orders.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<OrderDto>>(await _repositoryManager.OrdersRepository.GetAll(false, cancellationToken));
    }
}
