using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(
                    q => new Employee
                    {
                        Id = q.Id,
                        Email = q.Email,
                        FirstName = q.FirstName,
                        LastName = q.LastName,
                    }).ToList();
        }

        public async Task<Employee> GetEmployee(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return new Employee()
            {
                Id = employee.Id,
                Email= employee.Email,
                FirstName= employee.FirstName,
                LastName= employee.LastName,
            };
        }
    }
}
