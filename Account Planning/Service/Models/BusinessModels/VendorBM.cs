using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels
{
    public class VendorBM
    {
        //public int Id { get; set; }

        public string VendorName { get; set; }

        public string ServiceType { get; set; }
    }

    public class VendorListBM
    {
        public List<VendorBM> VendorList {get; set;}
    }
}
