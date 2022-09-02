using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Interfaces.Services
{
    public interface ISchedulesService
    {
        IEnumerable<Schedule> GetAll();
        Schedule GetById(Guid id);
        Schedule Create(ScheduleForCreationDto entityForCreation);
        bool Delete(Guid id);
        bool Update(ScheduleForUpdateDto entityForUpdate);
    }
}
