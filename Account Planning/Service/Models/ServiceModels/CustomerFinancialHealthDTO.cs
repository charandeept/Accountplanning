using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class CustomerFinancialHealthDTO
    {
        //public int Id { get; set; }
        public int FinancialHealth { get; set; }
        public List<QuestionnaireDTO> data { get; set; }

    }
}
