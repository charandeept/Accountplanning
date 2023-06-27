using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class QuestionnaireTableDTO
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
