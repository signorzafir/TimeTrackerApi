using TimeTrackerAPI.Dto.WorkEntry;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Repositories.Interfaces
{
    public interface IWorkEntryRepository
    {
        Task<IEnumerable<WorkEntry>> GetAllAsync();
        Task<WorkEntry?> GetByIdAsync(int id);
        Task<IEnumerable<WorkEntry>> GetByEmployeeIdAsync(int employeeId);
        Task AddAsync(WorkEntry workEntry);
        void Update(WorkEntry workEntry);
        void Delete(WorkEntry workEntry);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<WorkEntry>> GetWorkEntryBySearchAndEmployeeId(int employeeId, WorkEntrySearchDto SearchDto);
    }
}
