using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Interface;
using Com.ACSCorp.AccountPlanning.Service.Common.Authorization.Model;
using Com.ACSCorp.AccountPlanning.Service.Common.Models;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.ClaimRepository
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly AccountPlanningContext _context;
        public ClaimRepository(AccountPlanningContext context)
        {
            _context = context;
        }
        public CurrentUser GetUser(string Email)
        {
            var employee = _context.Users.FirstOrDefault(x=>x.UserEmail == Email);            

            var role = _context.UserRole.FirstOrDefault(x => x.UserRoleId == employee.UserRoleId);
            
            CurrentUser user = new CurrentUser()
            {
                Id = employee.Id,
                Name = employee.UserName,  
                Email = employee.UserEmail,
                IsActive = (bool)employee.IsActive,
                IsDeliveryManager = (role.Name == "Delivery Manager") ? true : false,
                IsLeader = (role.Name == "Leader") ? true : false,
                IsGuestUser = (role.Name == "GuestUser") ? true: false                

            };
            return user;
        }
    }
}
