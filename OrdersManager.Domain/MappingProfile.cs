using AutoMapper;
using OrdersManager.Domain.Extensions;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Feedback;
using OrdersManager.DTO.Order;
using OrdersManager.DTO.Schedule;

namespace OrdersManager.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feedback, FeedbackDto>();
            CreateMap<Order, OrderDto>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.Status)));
            CreateMap<Schedule, ScheduleDto>();

            CreateMap<FeedbackForCreationDto, Feedback>();
            CreateMap<OrderForCreationDto, Order>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.SetOrderStatus(x.Status)));
            CreateMap<ScheduleForCreationDto, Schedule>();

            CreateMap<FeedbackForUpdateDto, Feedback>();
            CreateMap<OrderForUpdateDto, Order>()
                .ForMember(sch => sch.Status, opt => opt.MapFrom(x => EnumExtensions.SetOrderStatus(x.Status)));
            CreateMap<ScheduleForUpdateDto, Schedule>();
        }
    }
}
