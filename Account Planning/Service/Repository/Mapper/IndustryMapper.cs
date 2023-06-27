using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class IndustryMapper
    {
        public static IndustryDTO GetIndustryDTO(DataRow dataRow)
        {
            return new IndustryDTO() 
            { 
                Id = Convert.ToInt32(dataRow[0]),
                Industry = Convert.ToString(dataRow[1]) 
            };
        }


        public static List<IndustryDTO> GetIndustryDTOs(DataTable dataTable)
        {
            List<IndustryDTO> list = new List<IndustryDTO>();

            if(dataTable.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(GetIndustryDTO(dr));
            }
            return list;
        }
    }
}
