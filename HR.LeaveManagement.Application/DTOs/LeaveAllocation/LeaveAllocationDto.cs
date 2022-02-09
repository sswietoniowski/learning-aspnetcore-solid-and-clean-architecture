using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Models.Identity;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto, ILeaveAllocationDto
    {
        public Employee Employee { get; set; }
        public string RequestingEmployeeId { get; set; }
        public int NumberDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
