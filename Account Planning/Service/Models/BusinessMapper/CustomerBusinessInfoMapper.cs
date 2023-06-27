using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{

    public class CustomerBusinessInfoMapper
    {
        public static CustomerBusinessInfoBM GetCustomerBusinessInfoBM(CustomerBusinessInfoDTO customerBusinessInfoDTO)
        {
            return new CustomerBusinessInfoBM()
            {
                CustomerId = customerBusinessInfoDTO.CustomerId,
                CustomerName = customerBusinessInfoDTO.CustomerName,
                Website = customerBusinessInfoDTO.Website,
                IndustryId=customerBusinessInfoDTO.IndustryId,
                IndustryName=customerBusinessInfoDTO.IndustryName,
                CompanySize=customerBusinessInfoDTO.CompanySize,
                HeadQuarters=customerBusinessInfoDTO.HeadQuarters,
                Speciality=customerBusinessInfoDTO.Speciality,
                ServicesOffered=customerBusinessInfoDTO.ServicesOffered,
                TechStack=customerBusinessInfoDTO.TechStack,
                TimeZoneId=customerBusinessInfoDTO.TimeZoneId,
                CreatedBy=customerBusinessInfoDTO.CreatedBy,
                ModifiedBy=customerBusinessInfoDTO.ModifiedBy,
                ModifiedOn=customerBusinessInfoDTO.ModifiedOn,
                ProjectEndDate=customerBusinessInfoDTO.ProjectEndDate,
            };
        }

        public static CustomerBusinessInfoDTO GetCustomerBusinessInfoDTO(CustomerBusinessInfoBM customerBusinessInfoBM)
        {
            return new CustomerBusinessInfoDTO()
            {
                CustomerId=customerBusinessInfoBM.CustomerId,
                CustomerName=customerBusinessInfoBM.CustomerName,
                Website=customerBusinessInfoBM.Website,
                IndustryId = customerBusinessInfoBM.IndustryId,
                IndustryName = customerBusinessInfoBM.IndustryName,
                CompanySize = customerBusinessInfoBM.CompanySize,
                HeadQuarters= customerBusinessInfoBM.HeadQuarters,
                Speciality = customerBusinessInfoBM.Speciality,
                ServicesOffered = customerBusinessInfoBM.ServicesOffered,
                TechStack = customerBusinessInfoBM.TechStack,
                TimeZoneId = customerBusinessInfoBM.TimeZoneId,
                CreatedBy = customerBusinessInfoBM.CreatedBy,
                ModifiedBy = customerBusinessInfoBM.ModifiedBy,
                ModifiedOn = customerBusinessInfoBM.ModifiedOn,
                ProjectEndDate = customerBusinessInfoBM.ProjectEndDate,
            };
        }
    }
}
