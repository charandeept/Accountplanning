using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CustomerServiceMapper
    {
        

        public static CustomerServiceDTO GetCustomerServiceDTO(DataRow dataRow)
        {
            return new CustomerServiceDTO() 
            { 
                //Id = Convert.ToInt32(dataRow[0]),
                CustomerService = Convert.ToString(dataRow[0]) 
            };
        }


        public static List<CustomerServiceDTO> GetCustomerServiceDTOs(DataTable dataTable)
        {
            List<CustomerServiceDTO> list = new List<CustomerServiceDTO>();

            if (dataTable.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(GetCustomerServiceDTO(dr));
            }
            return list;
        }
    }
}
