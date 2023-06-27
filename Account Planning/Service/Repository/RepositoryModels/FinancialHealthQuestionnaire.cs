using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels
{
    public class FinancialHealthQuestionnaire
    {
       // public int CustomerId { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public int OptionAValue { get; set; }
        public int OptionBValue { get; set; }
        public int OptionCValue { get; set; }
        public int OptionDValue { get; set; }
        public string FormControlName { get; set; }

    }
}
