using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CustomerServiceMapper
    {
        public static CustomerServiceBM GetCustomerServiceBM(CustomerServiceDTO customerServiceDTO)
        {
            return new CustomerServiceBM()
            {
               // Id = customerServiceDTO.Id,
                CustomerService = customerServiceDTO.CustomerService
            };
        }

        public static List<CustomerServiceBM> GetCustomerServiceBMs(List<CustomerServiceDTO> customerServiceDTOs)
        {
            List<CustomerServiceBM> list = new List<CustomerServiceBM>();

            foreach (CustomerServiceDTO customerServiceDTO in customerServiceDTOs)
            {
                list.Add(GetCustomerServiceBM(customerServiceDTO));
            }
            return list;
        }
    }
}
