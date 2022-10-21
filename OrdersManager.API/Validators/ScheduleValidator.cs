using FluentValidation;
using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;

namespace OrdersManager.API.Validators
{
    public class ScheduleForCreationValidator : AbstractValidator<ScheduleForCreationDto>
    {
        public ScheduleForCreationValidator()
        {
            RuleFor(x => x.StartTime).GreaterThan(DateTime.Now.AddMinutes(5)).WithMessage("You cannot order past tense!");
            RuleFor(x => x.StartTime.Hour).GreaterThan(8).LessThan(20).WithMessage("Spa works from 8:00 till 20:00!");
            RuleFor(x => x.EndTime.Hour).GreaterThan(8).LessThan(20).WithMessage("Spa works from 8:00 till 20:00!");
        }
    }
}
