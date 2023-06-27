namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class FilterParametersInImportUsers
    {
        public string ColumnName { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }    
}