using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLeaveRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _unitOfWork.LeaveRequestRepository.Get(request.Id);

            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }

            await _unitOfWork.LeaveRequestRepository.Delete(leaveRequest);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
