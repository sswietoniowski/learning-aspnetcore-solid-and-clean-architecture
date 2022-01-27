using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        public Task<IReadOnlyCollection<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    }
}
