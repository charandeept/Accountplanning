namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ImportUsers_FilterAndSort
    {
        public List<FilterParametersInImportUsers> Filter { get; set; }
        public string SearchText { get; set; }
        public string OrderColumn { get; set; }
        public string OrderType { get; set; }
    }
}
