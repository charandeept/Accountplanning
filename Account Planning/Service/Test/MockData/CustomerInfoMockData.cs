using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountPlanningTest.MockData
{
    public class CustomerInfoMockData
    {
        public static Result<CustomerBusinessInfoDTO> GetCustomerBusinessInfo()
        {
            var list = new CustomerBusinessInfoDTO();
            
            return Result.Ok(list);
        }

        public static Result<List<CustomerBusinessInfoDTO>> CustomerInfoDTOList()
        {
            var list = new List<CustomerBusinessInfoDTO>();
            {
                new CustomerBusinessInfoDTO();

            };
            return Result.Ok(list);
        }
    }
}
