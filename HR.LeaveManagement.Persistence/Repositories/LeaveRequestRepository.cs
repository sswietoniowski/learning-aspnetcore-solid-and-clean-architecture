using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System.Linq;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyCollection<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .Include(r => r.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(r => r.LeaveType)
                .FirstOrDefaultAsync(r => r.Id == id);

            return leaveRequest;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
        }

        public async Task<IReadOnlyCollection<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _dbContext.LeaveRequests.Where(q => q.RequestingEmployeeId == userId)
                .Include(r => r.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }
    }
}
