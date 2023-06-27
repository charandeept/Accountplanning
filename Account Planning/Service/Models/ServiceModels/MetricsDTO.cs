using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class MetricsDTO
    {
        public int? Id { get; set; }
        public int UserID { get; set; }
        public int MetricsID { get; set; }
        public int OperatorID { get; set; }
        public int Value { get; set; }
    }
}
