using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface
{
    public interface IClaimRepository
    {
        public CurrentUser GetUser(string Email);
    }
}
