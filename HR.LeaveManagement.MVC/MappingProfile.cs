using AutoMapper;
using HR.LeaveManagement.MVC.Services.Base;
using HR.LeaveManagement.MVC.Views.LeaveTypes;

namespace HR.LeaveManagement.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        }
    }
}
