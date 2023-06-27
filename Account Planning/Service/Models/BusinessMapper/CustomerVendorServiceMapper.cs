using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CustomerVendorServiceMapper
    {
        public static CustomerVendorServiceBM GetCustomerVendorServiceBM(CustomerVendorServiceDTO customerVendorServiceDTO)
        {
            return new CustomerVendorServiceBM()
            {
                VendorName = customerVendorServiceDTO.VendorName,
                ServiceType = customerVendorServiceDTO.ServiceType,
            };
        }
        public static List<CustomerVendorServiceBM> GetCustomerVendorServiceBMs(List<CustomerVendorServiceDTO> customerVendorServiceDTOs)
        {
            List<CustomerVendorServiceBM> list = new List<CustomerVendorServiceBM>();

            foreach (CustomerVendorServiceDTO customerVendorServiceDTO in customerVendorServiceDTOs)
            {
                list.Add(GetCustomerVendorServiceBM(customerVendorServiceDTO));
            }
            return list;
        }
    }
}
