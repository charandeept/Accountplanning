using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CSATDetailsMapper
    {
        public static CSATDetailsDTO GetCSATDetailsDTO(DataTable CSATDetails)
        {
            if (CSATDetails.Rows.Count == 0)
            {
                return null;
            }

            return new CSATDetailsDTO()
            {
                //CustomerId = Convert.ToInt32(CSATDetails.Rows[0][0]),
                CSATNumber = Convert.ToInt32(CSATDetails.Rows[0][1]),
                Comments = Convert.ToString(CSATDetails.Rows[0][2])
            };
        }

        public static CSATDetails GetCSATDetails(CSATDetailsDTO csatDetailsDTO)
        {
            return new CSATDetails()
            {
                CSATNumber = csatDetailsDTO.CSATNumber,
                CSATComments = csatDetailsDTO.Comments

            };
        }



        public static CSATDetailsDTO GetCSATDetailsDTOFromCustomerTable(CustomerInfoTable customerInfoTable)
        {
            return new CSATDetailsDTO()
            {
                CSATNumber = customerInfoTable.CSAT,
                Comments = customerInfoTable.CSATComments

                
            };



        }
    }
}
