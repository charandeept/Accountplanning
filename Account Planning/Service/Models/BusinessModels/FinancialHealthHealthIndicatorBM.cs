using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels
{
    public class FinancialHealthHealthIndicatorBM
    {
        public int CustomerId { get; set; }
        public int Id { get; set; }

        public int questionId { get; set; }
        public int OptionA { get; set; }
        public int OptionB { get; set; }
        public int OptionC { get; set; }
        public int OptionD { get; set; }
    }
}
