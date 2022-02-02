using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<IReadOnlyCollection<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    }
}
