using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<IReadOnlyCollection<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<IReadOnlyCollection<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
    }
}
