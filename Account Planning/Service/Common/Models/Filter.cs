using Com.ACSCorp.AccountPlanning.Service.Common.Enums;

namespace Com.ACSCorp.AccountPlanning.Service.Common.Models
{
    public class Filter
    {
        public string Name { get; set; }
        public Operator Operator { get; set; }
        public string FromValue { get; set; }
        public string ToValue { get; set; }
    }
}