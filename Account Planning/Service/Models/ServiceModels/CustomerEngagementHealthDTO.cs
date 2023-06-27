using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class CustomerEngagementHealthDTO
    {
        //public int Id { get; set; }
        public int EngagementHealth { get; set; }
        public List<QuestionnaireDTO> data { get; set; }
    }
}
