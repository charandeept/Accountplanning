using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class SearchDTO
    {
        public List<CustomerList> CustomerList { get; set; }
        public SearchDTO()
        {
            CustomerList = new List<CustomerList>();
        }
    }
}
