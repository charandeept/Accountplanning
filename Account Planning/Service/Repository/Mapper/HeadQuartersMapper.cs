using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class HeadQuartersMapper
    {
        public static HeadQuartersDTO GetHeadQuartersDTO(DataRow dataRow)
        {
            return new HeadQuartersDTO()
            {
                Id = Convert.ToInt32(dataRow[0]),
                HeadQuarters = Convert.ToString(dataRow[1]) 
            };
        }


        public static List<HeadQuartersDTO> GetHeadQuartersDTOs(DataTable dataTable)
        {
            List<HeadQuartersDTO> list = new List<HeadQuartersDTO>();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(GetHeadQuartersDTO(dr));
            }
            return list;
        }
    }
}
