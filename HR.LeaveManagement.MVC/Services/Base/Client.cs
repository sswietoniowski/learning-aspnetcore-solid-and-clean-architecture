﻿using System.Net.Http;

namespace HR.LeaveManagement.MVC.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient => _httpClient;
    }
}
