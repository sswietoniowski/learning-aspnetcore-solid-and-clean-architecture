using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class UpdateLeaveAllocationDto : BaseDto
    {
        public int NumberDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
