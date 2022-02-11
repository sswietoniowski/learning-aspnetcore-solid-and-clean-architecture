using HR.LeaveManagement.Application.Constants;
using HR.LeaveManagement.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeaveManagementDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private ILeaveRequestRepository _leaveRequestRepository;
        private ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationRepository LeaveAllocationRepository => _leaveAllocationRepository ??= new LeaveAllocationRepository(_context);

        public ILeaveRequestRepository LeaveRequestRepository => _leaveRequestRepository ??= new LeaveRequestRepository(_context);

        public ILeaveTypeRepository LeaveTypeRepository => _leaveTypeRepository ??= new LeaveTypeRepository(_context);

        public UnitOfWork(LeaveManagementDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
            await _context.SaveChangesAsync(userName);
        }
    }
}
