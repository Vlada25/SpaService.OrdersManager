﻿using AutoMapper;
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
    public class GetOrderByScheduleIdQueryHandler : IRequestHandler<GetOrderByScheduleIdQuery, OrderDto>
    {
        private readonly OrdersManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderByScheduleIdQueryHandler(OrdersManagerDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByScheduleIdQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<OrderDto>(
                await _dbContext.Orders.FirstOrDefaultAsync(o => o.ScheduleId.Equals(request.ScheduleId), cancellationToken));
    }
}
