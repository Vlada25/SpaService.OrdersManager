using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Interfaces.Services
{
    public interface ISchedulesService
    {
        IEnumerable<Schedule> GetAll();
        Schedule GetById(Guid id);
        Schedule Create(ScheduleForCreationDto entityForCreation);
        bool Delete(Guid id);
        bool DeleteByMasterId(Guid masterId);
        bool Update(ScheduleForUpdateDto entityForUpdate);
        bool UpdateMaster(MasterUpdated master);
    }
}
