namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FilterDTO
    {
        public List<Filter> Filter { get; set; }
        public FilterDTO()
        {
            Filter = new List<Filter>();
        }
    }
}
