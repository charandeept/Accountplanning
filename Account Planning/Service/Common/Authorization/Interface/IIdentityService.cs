using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model;
using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface
{
    public interface IIdentityService
    {
        public CurrentUser GetCurrentUser();
        public int GetCurrentUserId();
        public string GetCurrentUserEmail();

        public void SetUser(CurrentUser user);
        //public bool IsAdmin();
        public bool HasPermission(EmployeeRole role);
    }
}
