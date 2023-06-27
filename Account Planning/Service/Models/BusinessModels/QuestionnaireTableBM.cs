using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels
{
    public class QuestionnaireTableBM
    {
        public int QuestionId { get; set; }
        public int TypeId { get; set; }
        public string Question { get; set; }
        public int OptionA { get; set; }
        public int OptionB { get; set; }
        public int OptionC { get; set; }
        public int OptionD { get; set; }
        
    }
}
