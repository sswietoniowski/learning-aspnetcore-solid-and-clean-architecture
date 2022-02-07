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

        public LeaveTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            var leaveType = await _client.LeaveTypesGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<int>> DeleteLeaveType(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
