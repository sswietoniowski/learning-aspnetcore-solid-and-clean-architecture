using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;
using System;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        public LeaveAllocationService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }

        public async Task<Response<int>> CreateLeaveAllocations(int leaveTypeId)
        {
            try
            {
                var response = new Response<int>();
                var leaveAllocation = new CreateLeaveAllocationDto { LeaveTypeId = leaveTypeId };
                AddBearerToken();
                var apiResponse = await _client.LeaveAllocationsPOSTAsync(leaveAllocation);
                if (apiResponse.Success)
                {
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.ValidationErrors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }

                return response;

            }
            catch (ApiException ex)
            {

                return ConvertApiException<int>(ex);
            }
        }
    }
}
