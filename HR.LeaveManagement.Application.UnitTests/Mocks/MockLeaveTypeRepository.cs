using System.Collections.Generic;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    Name = "Test Vacation",
                    DefaultDays = 10
                },
                new LeaveType
                {
                    Id = 2,
                    Name = "Test Sick",
                    DefaultDays = 15
                },
                new LeaveType
                {
                    Id = 3,
                    Name = "Test Maternity",
                    DefaultDays = 90
                }
            };

            var mockRepository = new Mock<ILeaveTypeRepository>();
            mockRepository.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);
            mockRepository.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            return mockRepository;
        }
    }
}
