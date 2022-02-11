using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System.Linq;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyCollection<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocation
                .Include(a => a.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocation
                .Include(a => a.LeaveType)
                .FirstOrDefaultAsync(a => a.Id == id);

            return leaveAllocation;
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _dbContext.LeaveAllocation.AnyAsync(
                q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _dbContext.LeaveAllocation.AddRangeAsync(allocations);
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _dbContext.LeaveAllocation.FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId);
        }

        public async Task<IReadOnlyCollection<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocations = await _dbContext.LeaveAllocation.Where(a => a.EmployeeId == userId)
                .Include(a => a.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }
    }
}
