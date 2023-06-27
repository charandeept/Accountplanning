using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountPlanningTest.MockData
{
    public class CustomerUsersMockData
    {
        public static List<CustomerUser> GetCustomerUsers()
        {
            return new List<CustomerUser>()
            {
                new CustomerUser()
                {
                    Id=1,
                    Name="a",
                    CustomerId=1
                },
                new CustomerUser()
                {
                    Id=2,
                    Name="b",
                    CustomerId=2
                }
            };
        }
    }
}