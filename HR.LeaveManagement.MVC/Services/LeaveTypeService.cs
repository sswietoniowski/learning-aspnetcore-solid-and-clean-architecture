using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;
using HR.LeaveManagement.MVC.Views.LeaveTypes;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public LeaveTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            throw new System.NotImplementedException();
        }

        public Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateLeaveType(LeaveTypeVM leaveType)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteLeaveType(LeaveTypeVM leaveType)
        {
            throw new System.NotImplementedException();
        }
    }
}
