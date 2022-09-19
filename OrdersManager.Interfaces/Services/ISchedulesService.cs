using OrdersManager.Domain.Models;
using OrdersManager.DTO.Schedule;
using SpaService.Domain.Messages.Person;
using SpaService.Domain.Messages.Service;

namespace OrdersManager.Interfaces.Services
{
    public interface ISchedulesService
    {
        Task<IEnumerable<Schedule>> GetAll();
        Task<Schedule> GetById(Guid id);
        Task<IEnumerable<Schedule>> GetByServiceId(Guid serviceId);
        Task<Schedule> Create(ScheduleForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteByMasterId(Guid masterId);
        Task<bool> DeleteByServiceId(Guid serviceId);
        Task<bool> Update(ScheduleForUpdateDto entityForUpdate);
        Task<bool> UpdateMaster(MasterUpdated master);
        Task<bool> UpdateService(ServiceUpdated service);
        Task<bool> UpdateSchedules(IEnumerable<Schedule> entities);
    }
}
