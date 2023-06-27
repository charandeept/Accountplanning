using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class CountOfEnabler
    {
        public int EnablerTypeId { get; set; }

        public string EnablerTitle { get; set; }
        public int Count { get; set; }
    }
}
