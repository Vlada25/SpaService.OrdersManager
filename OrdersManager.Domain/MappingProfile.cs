using AutoMapper;
using OrdersManager.Domain.Extensions;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Feedback;
using OrdersManager.DTO.Order;
using OrdersManager.DTO.Schedule;
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
            CreateMap<Schedule, ScheduleDto>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.Status)));

            CreateMap<FeedbackForCreationDto, Feedback>();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<ScheduleForCreationDto, Schedule>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.SetOrderStatus(x.Status)));

            CreateMap<FeedbackForUpdateDto, Feedback>();
            CreateMap<OrderForUpdateDto, Order>();
            CreateMap<ScheduleForUpdateDto, Schedule>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.SetOrderStatus(x.Status)));
        }
    }
}
