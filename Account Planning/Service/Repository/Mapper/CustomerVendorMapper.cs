using Com.ACSCorp.AccountPlanning.Service.Models;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CustomerVendorMapper
	{
		
		public static CustomerVendorDTO GetCustomerVendorDTO(CustomerVendor customerVendor)
        {
			return new CustomerVendorDTO()
			{
				//Id = customerVendor.Id,
				CustomerId = customerVendor.CustomerId,
				VendorId = customerVendor.VendorId
			};
        }

		public static CustomerVendor GetCustomerVendor(CustomerVendorDTO customerVendorDTO)
        {
			return new CustomerVendor()
			{
				//Id = customerVendorDTO.Id,
				CustomerId = customerVendorDTO.CustomerId,
				VendorId = customerVendorDTO.VendorId
			};
        }

		public static List<CustomerVendorDTO> GetCustomerVendorDTOs(List<CustomerVendor> customerVendors)
		{
			List<CustomerVendorDTO> customerVendorDTOs = new List<CustomerVendorDTO>();
			foreach (CustomerVendor cv in customerVendors)
			{
				customerVendorDTOs.Add(GetCustomerVendorDTO(cv));
			}
			return customerVendorDTOs;
		}


	}
}


