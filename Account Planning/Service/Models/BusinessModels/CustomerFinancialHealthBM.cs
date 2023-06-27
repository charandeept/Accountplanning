using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels
{
    public class CustomerFinancialHealthBM
    {
        //public int Id { get; set; }
        public int FinancialHealth { get; set; }

        public List<QuestionnaireBM> data { get; set; }
    }
}
