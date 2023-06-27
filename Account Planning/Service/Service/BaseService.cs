using Com.ACSCorp.AccountPlanning.Service.IService;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Service
{
    public class BaseService : IBaseService
    {
        private readonly IConfiguration Configuration;

        public BaseService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string ApiUrl => Configuration.GetSection("APIUrl").Value;
    }
}