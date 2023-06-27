using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class Customer
    {
        public int userId { get; set; }
        public int userRoleId { get; set; }
        public string userEmail { get; set; }
        public int pageNumber { get; set; } = 1;
        public int rowsOfPage { get; set; } = 20;
        public string sortingColumn { get; set; } = "CBI.Id";
        public string sortType { get; set; } = "ASC";
    }
}
