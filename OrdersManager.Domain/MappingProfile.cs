using AutoMapper;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Feedback;
using OrdersManager.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feedback, FeedbackDto>();
            CreateMap<Order, OrderDto>();

            CreateMap<FeedbackForCreationDto, Feedback>();
            CreateMap<OrderForCreationDto, Order>();

            CreateMap<FeedbackForUpdateDto, Feedback>();
            CreateMap<OrderForUpdateDto, Order>();
        }
    }
}
