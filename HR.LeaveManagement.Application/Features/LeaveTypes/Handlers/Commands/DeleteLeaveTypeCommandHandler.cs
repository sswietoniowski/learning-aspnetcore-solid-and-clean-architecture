using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLeaveTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _unitOfWork.LeaveTypeRepository.Get(request.Id);

            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            await _unitOfWork.LeaveTypeRepository.Delete(leaveType);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
