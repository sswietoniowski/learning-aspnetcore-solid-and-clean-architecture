using System.Collections.Generic;

namespace HR.LeaveManagement.Application.Responses
{
    public class BaseCommonResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
