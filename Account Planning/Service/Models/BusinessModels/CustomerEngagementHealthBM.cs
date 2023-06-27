using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels
{
    public class CustomerEngagementHealthBM
    {

        //public int Id { get; set; }
        public int EngagementHealth { get; set; }

        public List<QuestionnaireBM> data { get; set; }

    }
}
