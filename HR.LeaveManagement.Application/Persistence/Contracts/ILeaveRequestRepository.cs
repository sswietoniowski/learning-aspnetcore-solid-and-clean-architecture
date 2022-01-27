using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<IReadOnlyCollection<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
    }
}
