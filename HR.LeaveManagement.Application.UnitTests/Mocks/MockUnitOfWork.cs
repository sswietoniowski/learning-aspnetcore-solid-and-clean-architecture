using HR.LeaveManagement.Application.Contracts.Persistence;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUoW = new Mock<IUnitOfWork>();
            var mockLeaveRequestRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();
            mockUoW.Setup(r => r.LeaveTypeRepository).Returns(mockLeaveRequestRepository.Object);
            return mockUoW;
        }
    }
}
