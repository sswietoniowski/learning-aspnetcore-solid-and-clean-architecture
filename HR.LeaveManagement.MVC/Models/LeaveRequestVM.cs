using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.MVC.Views.LeaveTypes
{
    public class LeaveRequestVM
    {
    }

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

    public class AdminLeaveRequestViewVM
    {
    }

    public class EmployeeLeaveRequestViewVM
    {
    }
}
