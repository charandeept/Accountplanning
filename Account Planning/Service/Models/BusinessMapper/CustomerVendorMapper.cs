using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CustomerVendorMapper
    {
        public static CustomerVendorDTO GetCustomerVendorDTO(CustomerVendorBM customerVendorBM)
        {
            return new CustomerVendorDTO()
            {
                CustomerId = customerVendorBM.CustomerId,
                VendorId = customerVendorBM.VendorId,

            };
        }

        public static List<CustomerVendorDTO> GetCustomerVendorDTOList(List<CustomerVendorBM> customerVendorBM)
        {
            List<CustomerVendorDTO> customerVendorList =  new List<CustomerVendorDTO>();
            foreach (CustomerVendorBM vendor in customerVendorBM)
            {
                customerVendorList.Add(GetCustomerVendorDTO(vendor));
            }
            return customerVendorList;

        }

        public static CustomerVendorBM GetCustomerVendorBM (CustomerVendorDTO customerVendorDTO)
        {
            return new CustomerVendorBM()
            {
                CustomerId = customerVendorDTO.CustomerId,
                VendorId=customerVendorDTO.VendorId,
            };
        }

        public static List<CustomerVendorBM> GetCustomerVendorBMList(List<CustomerVendorDTO> customerVendorDTO)
        {
            List<CustomerVendorBM> customerVendorList = new List<CustomerVendorBM>();
            foreach(CustomerVendorDTO vendor in customerVendorDTO)
            {
                customerVendorList.Add  (GetCustomerVendorBM(vendor));
            }
            return customerVendorList;
        }
    }
}
