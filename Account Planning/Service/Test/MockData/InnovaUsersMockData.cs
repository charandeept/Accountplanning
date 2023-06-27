using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPlanningTest.MockData
{
    public class InnovaUsersMockData
    {
        public static List<Users> GetInnovaUsers()
        {
            return new List<Users>()
            {
                new Users()
                {
                    Id=1,
                    UserName="x"
                }
            };
        }
    }
}
