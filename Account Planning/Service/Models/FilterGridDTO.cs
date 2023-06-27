namespace Com.ACSCorp.AccountPlanning.Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FilterGridDTO
    {
        public int UserId { get; set; }
        public string ColumnName { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }

    }
}
