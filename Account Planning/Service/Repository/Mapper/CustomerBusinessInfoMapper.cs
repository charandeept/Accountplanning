using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Data;
using CustomerInfoTable = Com.ACSCorp.AccountPlanning.Service.Repository.Models.CustomerInfoTable;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{

    public class CustomerBusinessInfoMapper
    {
        public static CustomerBusinessInfoDTO GetCustomerBusinessInfoDTO(DataTable customerBusinessInfo)
        {
            if(customerBusinessInfo.Rows.Count == 0)
            {
                return null;
            }

            return new CustomerBusinessInfoDTO()
            {
                //CustomerId = Convert.ToInt32(customerBusinessInfo.Rows[0][1]),

                CustomerId = Convert.ToInt32(customerBusinessInfo.Rows[0][0]),
                CustomerName = Convert.ToString(customerBusinessInfo.Rows[0][1]),
                Website = customerBusinessInfo.Rows[0][2].ToString(),
                IndustryId = Convert.ToInt32(customerBusinessInfo.Rows[0][3]),
                IndustryName = customerBusinessInfo.Rows[0][4].ToString(),
                CompanySize = Convert.ToInt32(customerBusinessInfo.Rows[0][5]),
                HeadQuarters = customerBusinessInfo.Rows[0][6].ToString(),
                Speciality = customerBusinessInfo.Rows[0][7].ToString(),
                ServicesOffered = customerBusinessInfo.Rows[0][8].ToString(),
                TechStack = customerBusinessInfo.Rows[0][9].ToString(),
                ModifiedBy = Convert.ToInt32(customerBusinessInfo.Rows[0][10]),
                ModifiedOn = Convert.ToDateTime(customerBusinessInfo.Rows[0][11]),
                ProjectEndDate = Convert.ToDateTime(customerBusinessInfo.Rows[0][12])

            };
               
        }

        public static CustomerBusinessInfo GetCustomerBussinessInfo(CustomerBusinessInfoDTO customerBusinessInfoDTO)
        {
            return new CustomerBusinessInfo()
            {
                //CustomerId = customerBusinessInfoDTO.CustomerId,
                Website = customerBusinessInfoDTO.Website,
                IndustryId = customerBusinessInfoDTO.IndustryId,
                CompanySize = customerBusinessInfoDTO.CompanySize,
                HeadQuarters = customerBusinessInfoDTO.HeadQuarters,
                Speciality = customerBusinessInfoDTO.Speciality,
                ServicesOffered = customerBusinessInfoDTO.ServicesOffered,
                TimeZoneId = customerBusinessInfoDTO.TimeZoneId,
                TechStack = customerBusinessInfoDTO.TechStack,
                CreatedBy = customerBusinessInfoDTO.CreatedBy,
                ModifiedBy = customerBusinessInfoDTO.ModifiedBy,
                ModifiedOn = customerBusinessInfoDTO.ModifiedOn,
                ProjectEndDate = customerBusinessInfoDTO.ProjectEndDate
            };
        }

        public static CustomerInfoTable GetCustomerInfoTable(CustomerBusinessInfoDTO customerBusinessInfoDTO)
        {
            return new CustomerInfoTable()
            {
                //CustomerId = customerBusinessInfoDTO.CustomerId,
                name = customerBusinessInfoDTO.CustomerName,
                Website = customerBusinessInfoDTO.Website,
                IndustryId = customerBusinessInfoDTO.IndustryId,
                CompanySize = customerBusinessInfoDTO.CompanySize,
                HeadQuarters = customerBusinessInfoDTO.HeadQuarters,
                Speciality = customerBusinessInfoDTO.Speciality,
                ServicesOffered = customerBusinessInfoDTO.ServicesOffered,
                TimeZoneId = customerBusinessInfoDTO.TimeZoneId,
                TechStack = customerBusinessInfoDTO.TechStack,
                CreatedBy = customerBusinessInfoDTO.CreatedBy,
                ModifiedBy = customerBusinessInfoDTO.ModifiedBy,
                ModifiedOn = customerBusinessInfoDTO.ModifiedOn,
                ProjectEndDate = customerBusinessInfoDTO.ProjectEndDate
            };
        }



        public static CustomerBusinessInfoDTO GetCustomerBusinessDTOFromCustomerTable(CustomerInfoTable customerInfoTable)
        {
            return new CustomerBusinessInfoDTO()
            {
                CustomerId = customerInfoTable.Id,
                CustomerName = customerInfoTable.name,
                Website = customerInfoTable.Website,
                IndustryId = customerInfoTable.IndustryId,
                CompanySize = customerInfoTable.CompanySize,
                HeadQuarters = customerInfoTable.HeadQuarters,
                Speciality = customerInfoTable.Speciality,
                ServicesOffered = customerInfoTable.ServicesOffered,
                TimeZoneId = customerInfoTable.TimeZoneId,
                TechStack = customerInfoTable.TechStack,
                CreatedBy = customerInfoTable.CreatedBy,
                ModifiedBy = customerInfoTable.ModifiedBy,
                ModifiedOn = customerInfoTable.ModifiedOn,
                ProjectEndDate = customerInfoTable.ProjectEndDate
            };



        }

    }
}
