using Com.ACSCorp.AccountPlanning.Service.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model
{
    public class CurrentUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }        
        public bool IsActive { get; set; }        
        public bool IsDeliveryManager { get; set; }
        public bool IsLeader { get; set; }
        public bool IsGuestUser { get; set; }
        public List<EmployeeRole> Roles { get; set; }
    }
}
