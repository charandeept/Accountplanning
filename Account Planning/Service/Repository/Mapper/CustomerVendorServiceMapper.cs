using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CustomerVendorServiceMapper
    {
        //public static CustomerVendorServiceDTO GetCustomerVendorServiceDTO(CustomerVendorService customerVendorService)
        //{
        //    return new CustomerVendorServiceDTO()
        //    {
        //        Id = customerVendorService.Id,
        //        VendorId = customerVendorService.VendorId,
        //        VendorName = customerVendorService.VendorName,
        //        ServiceType = customerVendorService.ServiceType                                                          
        //    };
        //}

        //public static List<CustomerVendorServiceDTO> GetCustomerVendorServiceDTOs(List<CustomerVendorService> customerVendorService)
        //{
        //    List<CustomerVendorServiceDTO> list = new List<CustomerVendorServiceDTO>();
        //    foreach(CustomerVendorService cvr in customerVendorService)
        //    {
        //        list.Add(GetCustomerVendorServiceDTO(cvr));
        //    }
        //    return list;

        //}

        public static CustomerVendorServiceDTO GetCustomerVendorServiceDTO(DataRow customerVendorService)
        {
            return new CustomerVendorServiceDTO()
            {
                //Id = Convert.ToInt32(customerVendorService[0]),
                //VendorId = Convert.ToInt32(customerVendorService[1]),
                VendorName = Convert.ToString(customerVendorService[2]),
                ServiceType = Convert.ToString(customerVendorService[3])
            };
        }

        public static List<CustomerVendorServiceDTO> GetCustomerVendorServiceDTOs(DataTable customerVendorService)
        {
            List<CustomerVendorServiceDTO> list = new List<CustomerVendorServiceDTO>();
            if(customerVendorService.Rows.Count == 0)
            {
                return null;
            }
            foreach (DataRow cvr in customerVendorService.Rows)
            {
                list.Add(GetCustomerVendorServiceDTO(cvr));
            }
            return list;
        }

    }
}
