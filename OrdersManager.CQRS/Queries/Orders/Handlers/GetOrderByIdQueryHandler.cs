using AutoMapper;
using MediatR;
using OrdersManager.DTO.Order;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Orders.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<OrderDto>(
                await _repositoryManager.OrdersRepository.GetById(request.Id, false, cancellationToken));
    }
}
