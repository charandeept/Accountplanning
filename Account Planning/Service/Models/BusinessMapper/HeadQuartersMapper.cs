using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class HeadQuartersMapper
    {
        public static HeadQuartersBM GetHeadQuartersBM(HeadQuartersDTO headQuartersDTO)
        {
            return new HeadQuartersBM()
            {
                Id = headQuartersDTO.Id,
                HeadQuarters = headQuartersDTO.HeadQuarters
            };
        }

        public static List<HeadQuartersBM> GetHeadQuartersBMs(List<HeadQuartersDTO> headQuartersDTOs)
        {
            List<HeadQuartersBM> list = new List<HeadQuartersBM>();

            foreach (HeadQuartersDTO headQuartersDTO in headQuartersDTOs)
            {
                list.Add(GetHeadQuartersBM(headQuartersDTO));
            }
            return list;
        }
    }
}
