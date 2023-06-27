using System;
using System.Collections.Generic;
using Com.ACSCorp.AccountPlanning.Service.Models;

namespace Com.ACSCorp.AccountPlanning.Service.Models
{
    public class DashboardDTO
    {
        public List<EngagementHealth> EngagementHealths { get; set; }
        public List<FinancialHealth> FinancialHealths { get; set; }
        public List<Metrics> Metric { get; set; }
        public List<NoOfAccounts> NoOfAccounts { get; set; }
        public DashboardDTO()
        {
            EngagementHealths = new List<EngagementHealth>();
            FinancialHealths = new List<FinancialHealth>();
            Metric = new List<Metrics>();
            NoOfAccounts = new List<NoOfAccounts>();
        }
    }
}





