using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class VendorMapper
    {
        public static VendorBM GetVendorBM(VendorDTO vendorDTO)
        {
            return new VendorBM()
            {
                VendorName = vendorDTO.vendorName,
                ServiceType = vendorDTO.serviceType,
            };
        }

        public static VendorDTO GetVendorDTO (VendorBM vendorBM)
        {
            return new VendorDTO()
            {
                vendorName = vendorBM.VendorName,
                serviceType = vendorBM.ServiceType,
            };
        }
    }
}
