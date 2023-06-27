using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model;
using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Implementation
{
    public class IdentityService : IIdentityService
    {
        private CurrentUser CurrentUser { get; set; }

        public IdentityService()
        {
        }

        public CurrentUser GetCurrentUser()
        {
            return CurrentUser;
        }

        public int GetCurrentUserId()
        {
            return CurrentUser == null ? default : CurrentUser.Id;
        }

        public string GetCurrentUserEmail()
        {
            return CurrentUser?.Email;
        }

        //public bool IsAdmin()
        //{
        //    return CurrentUser.IsAdmin;
        //}

        public bool HasPermission(EmployeeRole role)
        {
            return CurrentUser.Roles
                .Any(c => c == role);
        }

        public void SetUser(CurrentUser currentUser)
        {
            CurrentUser = currentUser;
        }
    }
}
