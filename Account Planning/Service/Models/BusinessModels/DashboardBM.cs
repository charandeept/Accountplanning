using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels
{
    public class DashboardBM
    {
        public List<EngagementHealth> EngagementHealths { get; set; }
        public List<FinancialHealth> FinancialHealths { get; set; }
        public List<Metrics> Metric { get; set; }
        public List<NoOfAccounts> NoOfAccounts { get; set; }
        public DashboardBM()
        {
            EngagementHealths = new List<EngagementHealth>();
            FinancialHealths = new List<FinancialHealth>();
            Metric = new List<Metrics>();
            NoOfAccounts = new List<NoOfAccounts>();
        }
    }
}
