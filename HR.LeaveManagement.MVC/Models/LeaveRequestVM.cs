using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.MVC.Views.LeaveTypes
{
    public class CreateLeaveRequestVM
    {
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public SelectList LeaveTypes { get; set; }
        [Required]
        [Display(Name = "Laeve Type")]
        public int LeaveTypeId { get; set; }
        [MaxLength(300)]
        [Display(Name = "Comments")]
        public string RequestComments { get; set; }
    }

    public class LeaveRequestVM : CreateLeaveRequestVM
    {
        public int Id { get; set; }
        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }
        [Display(Name = "Approval State")]
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
        public EmployeeVM Employee { get; set; }
    }

    public class AdminLeaveRequestViewVM
    {
        [Display(Name = "Total Number Of Requests")]
        public int TotalRequests { get; set; }
        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }

    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; internal set; }
        public List<LeaveRequestVM> LeaveRequests { get; internal set; }
    }
}
