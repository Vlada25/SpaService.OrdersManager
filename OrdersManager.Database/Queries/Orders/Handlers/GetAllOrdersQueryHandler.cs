using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database.Queries.Orders;
using OrdersManager.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Queries.Orders.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly OrdersManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(OrdersManagerDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<OrderDto>>(await _dbContext.Orders.ToListAsync(cancellationToken));
    }
}
