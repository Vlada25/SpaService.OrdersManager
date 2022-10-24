﻿using AutoMapper;
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
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly OrdersManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(OrdersManagerDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<OrderDto>(
                await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id.Equals(request.Id), cancellationToken));
    }
}
