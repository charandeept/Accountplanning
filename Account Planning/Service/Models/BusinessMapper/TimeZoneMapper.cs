using System;
using System.Collections.Generic;
using System.Text;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class TimeZoneMapper
    {
        public static TimeZoneBM GetTimeZoneBM(TimeZoneDTO timeZoneDTO)
        {
            return new TimeZoneBM()
            {
                Id = timeZoneDTO.Id,
                TimeZone = timeZoneDTO.TimeZone
            };
        }

        public static List<TimeZoneBM> GetTimeZoneBMs(List<TimeZoneDTO> timeZoneDTOs)
        {
            List<TimeZoneBM> list = new List<TimeZoneBM>();

            foreach(TimeZoneDTO timeZoneDTO in timeZoneDTOs)
            {
                list.Add(GetTimeZoneBM(timeZoneDTO));
            }
            return list;
        }
    }
}
