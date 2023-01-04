using AutoMapper;
using OrdersManager.CQRS.Commands.Feedbacks;
using OrdersManager.CQRS.Commands.Orders;
using OrdersManager.CQRS.Commands.Schedules;
using OrdersManager.Domain.Extensions;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Feedback;
using OrdersManager.DTO.Order;
using OrdersManager.DTO.Schedule;

namespace OrdersManager.CQRS
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feedback, FeedbackDto>();
            CreateMap<CreateFeedbackCommand, Feedback>();
            CreateMap<UpdateFeedbackCommand, Feedback>();

            CreateMap<Order, OrderDto>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.Status)));
            CreateMap<OrderDto, Order>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.SetOrderStatus(x.Status)));
            CreateMap<CreateOrderCommand, Order>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.SetOrderStatus(x.Status)));
            CreateMap<UpdateOrderCommand, Order>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.SetOrderStatus(x.Status)));

            CreateMap<Schedule, ScheduleDto>();
            CreateMap<CreateScheduleCommand, Schedule>();
            CreateMap<UpdateScheduleCommand, Schedule>();
        }
    }
}
