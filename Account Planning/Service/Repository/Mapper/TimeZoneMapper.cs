using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class TimeZoneMapper
    {
        public static TimeZoneDTO GetTimeZoneDTO(DataRow dataRow)
        {
            return new TimeZoneDTO() 
            { 
                Id = Convert.ToInt32(dataRow[0]),
                TimeZone = Convert.ToString(dataRow[1]) 
            };
        }


        public static List<TimeZoneDTO> GetTimeZoneDTOs(DataTable dataTable)
        {
            List<TimeZoneDTO> list = new List<TimeZoneDTO>();

            if(dataTable.Rows.Count == 0) { return null; }

            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(GetTimeZoneDTO(dr));
            }
            return list;
        }

    }
}
