﻿using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto : BaseDto
    {
        public int NumberDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}