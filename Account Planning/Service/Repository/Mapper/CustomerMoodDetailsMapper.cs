using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CustomerMoodDetailsMapper
    {
        public static CustomerMoodDetailsDTO GetCustomerMoodDetailsDTO(DataTable customerMoodDetails)
        {
            if(customerMoodDetails.Rows.Count == 0)
            {
                return null;
            }
            return new CustomerMoodDetailsDTO()
            {
                //Id = Convert.ToInt32(customerMoodDetails.Rows[0][0]),
                CustomerMood = Convert.ToInt32(customerMoodDetails.Rows[0][1])
            };
        }

        public static CustomerMoodDetailsDTO GetCustomerMoodDTO(CustomerInfoTable customerInfo)
        {
            return new CustomerMoodDetailsDTO()
            {
                //Id = customerInfo.Id,
                CustomerMood = customerInfo.CustomerMood
            };
        }

    }
}
