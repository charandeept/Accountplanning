using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CustomerMoodDetailsMapper
    {
        public static CustomerMoodDetailsBM GetCustomerMoodDetailsBM (CustomerMoodDetailsDTO customerMoodDetailsDTO)
        {
            return new CustomerMoodDetailsBM()
            {
                CustomerMood = customerMoodDetailsDTO.CustomerMood
            };
        }

        public static CustomerMoodDetailsDTO GetCustomerMoodDetailsDTO(CustomerMoodDetailsBM customerMoodDetailsBM)
        {
            return new CustomerMoodDetailsDTO()
            {
                CustomerMood = customerMoodDetailsBM.CustomerMood
            };
        }
    }
}
