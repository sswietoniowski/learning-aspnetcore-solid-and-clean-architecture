using HR.LeaveManagement.Application.DTOs;
using MediatR;
using System.Collections.Generic;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
