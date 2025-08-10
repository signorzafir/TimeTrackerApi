using Microsoft.EntityFrameworkCore;
using TimeTrackerAPI.Data;
using TimeTrackerAPI.Models;
using TimeTrackerAPI.Repositories.Interfaces;

namespace TimeTrackerAPI.Repositories
{
    public class WorkEntryRepository : IWorkEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkEntry>> GetAllAsync()
        {
            return await _context.WorkEntries.ToListAsync();
        }

        public async Task<WorkEntry?> GetByIdAsync(int id)
        {
            return await _context.WorkEntries.FindAsync(id);
        }

        public async Task<IEnumerable<WorkEntry>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.WorkEntries
                .Where(w => w.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task AddAsync(WorkEntry workEntry)
        {
            await _context.WorkEntries.AddAsync(workEntry);
        }

        public void Update(WorkEntry workEntry)
        {
            _context.WorkEntries.Update(workEntry);
        }

        public void Delete(WorkEntry workEntry)
        {
            _context.WorkEntries.Remove(workEntry);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
