using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;
using SpaService.Domain.Messages.Person;
using SpaService.Domain.Messages.Service;

namespace OrdersManager.Interfaces.Services
{
    public interface ISchedulesService
    {
        IEnumerable<Schedule> GetAll();
        Schedule GetById(Guid id);
        IEnumerable<Schedule> GetByServiceId(Guid serviceId);
        Schedule Create(ScheduleForCreationDto entityForCreation);
        bool Delete(Guid id);
        bool DeleteByMasterId(Guid masterId);
        bool DeleteByServiceId(Guid serviceId);
        bool Update(ScheduleForUpdateDto entityForUpdate);
        bool UpdateMaster(MasterUpdated master);
        bool UpdateService(ServiceUpdated service);
    }
}
