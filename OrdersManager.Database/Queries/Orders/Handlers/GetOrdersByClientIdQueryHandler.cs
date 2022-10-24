using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Queries.Orders.Handlers
{
    public class GetOrdersByClientIdQueryHandler : IRequestHandler<GetOrdersByClientIdQuery, IEnumerable<OrderDto>>
    {
        private readonly OrdersManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrdersByClientIdQueryHandler(OrdersManagerDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByClientIdQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<OrderDto>>(
                await _dbContext.Orders.Where(o => o.ClientId == request.ClientId).ToListAsync());
    }
}
