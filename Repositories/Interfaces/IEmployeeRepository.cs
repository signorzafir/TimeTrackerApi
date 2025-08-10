using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee?> GetByUserIdAsync(string userId);
        Task<Employee?> GetWithWorkEntriesAsync(int id);
        Task AddAsync(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Task<bool> SaveChangesAsync();
    }
}
