using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _allocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository allocationRepository, IMapper mapper)
        {
            _allocationRepository = allocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _allocationRepository.GetLeaveAllocationsWithDetails();
            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
        }
    }
}
