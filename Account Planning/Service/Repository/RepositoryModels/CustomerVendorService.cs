using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Models
{
    public class CustomerVendorService
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string ServiceType { get; set; }


    }
}
