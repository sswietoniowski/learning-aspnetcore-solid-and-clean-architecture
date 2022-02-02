using HR.LeaveManagement.Application.Models;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
