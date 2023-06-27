using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class EnablerDTO
    {
        public List<Enabler> Enablers { get; set; }

        public List<CountOfEnabler> Count { get; set; }
        public EnablerDTO()
        {
            Count = new List<CountOfEnabler>();
            Enablers = new List<Enabler>();
        }
    }
}
