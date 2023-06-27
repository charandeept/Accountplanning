namespace AccountPlanningTest.MockData
{
    using Com.ACSCorp.AccountPlanning.Service.Models;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DashboardMockData
    {
        public static DashboardDTO DashboardData()
        {
            DashboardDTO users = new DashboardDTO();
            var user = new EngagementHealth()
            {
                Customername = "innova",
                Engagementvalue = 5,
            };
            users.EngagementHealths.Add(user);
            var user1 = new FinancialHealth()
            {
                Customername = "ggk",
                Financialvalue = 5,
            };
            users.FinancialHealths.Add(user1);
            var user2 = new Metrics()
            {
                Cardid = 3,
                Userid = 2,
                Metricid = 1,
                Operatorid = 1,
                Metricvalue = 3,
            };
            users.Metric.Add(user2);
            var user3 = new NoOfAccounts()
            {
                NoofAccounts = 10
            };
            users.NoOfAccounts.Add(user3);

            return users;
        }
        public static SearchDTO SearchCustomer()
        {
            SearchDTO CustomersList = new SearchDTO();
            var user = new CustomerList()
            {
                customername = "acs",
                customerid = 5

            };
            var user1 = new CustomerList()
            {
                customerid = 7,
                customername = "innova"

            };
            CustomersList.CustomerList.Add(user);
            CustomersList.CustomerList.Add(user1);
            return CustomersList;
        }
        public static List<AccountDetailsDTO> NoOfAccounts()
        {
            return new List<AccountDetailsDTO>
            {
                new AccountDetailsDTO
                {
                    customerName="abcd",
                    service="efgh"
                },
            };
        }

        public static List<CustomerDTO> GetCustomerList()
        {
            return new List<CustomerDTO>
            {
                new CustomerDTO
                {
                    CustomerId = 1,
                    CustomerName="TCS",
                    //CreatedOn=2022-12-09 02:39:55.097,
                    ModifiedBy="Tata",
                    //ModifiedOn="10/05/2022"
                },
            };
        }

        public static bool CreateMetrics()
        {
            var record = new MetricsDTO()
            {
                Id = 0,
                UserID = 2,
                MetricsID = 1,
                OperatorID = 1,
                Value = 3
            };
            return true;
        }

        public static bool RemoveMetrics()
        {
            new MetricsDTO()
            {
                Id = 0,
                UserID = 2,
                MetricsID = 1,
                OperatorID = 1,
                Value = 3
            };
            return true;
        }

        public static FilterDTO CustomerFilter()
        {
            FilterDTO users = new FilterDTO();
            Filter user1 = new Filter()
            {
                CreatedOn = Convert.ToDateTime("15/01/2023"),
                CustomerName = "ACS",
                ModifiedBy = "Virat Kohli",
                ModifiedOn = Convert.ToDateTime("25/01/2023"),
            };
            users.Filter.Add(user1);
            return users;
        }
    }
}
