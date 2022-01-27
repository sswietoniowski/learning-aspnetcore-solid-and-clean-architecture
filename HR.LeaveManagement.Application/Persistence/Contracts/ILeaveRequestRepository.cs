﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        public Task<IReadOnlyCollection<LeaveRequest>> GetLeaveRequestsWithDetails();
        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    }
}