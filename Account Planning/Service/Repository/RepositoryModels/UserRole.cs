using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
