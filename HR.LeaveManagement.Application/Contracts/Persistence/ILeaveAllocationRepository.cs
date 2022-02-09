using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<IReadOnlyCollection<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<IReadOnlyCollection<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
        Task AddAllocations(List<LeaveAllocation> allocations);
        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
    }
}
