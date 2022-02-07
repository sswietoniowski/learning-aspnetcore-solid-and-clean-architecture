using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.MVC.Views.LeaveTypes
{
    public class CreateLeaveTypeVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default Number Of Days")]
        public int DefaultDays { get; set; }
    }

    public class LeaveTypeVM : CreateLeaveTypeVM
    {
        public int Id { get; set; }
    }
}
