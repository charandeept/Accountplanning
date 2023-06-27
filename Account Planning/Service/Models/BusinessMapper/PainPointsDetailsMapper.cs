using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
     public class PainPointsDetailsMapper
    {
        public static PainPointsDetailsBM GetPainPointsDetailsBM(PainPointsDetailsDTO painPointsDetailsDTO)
        {
            return new PainPointsDetailsBM()
            {
                PainPoints = painPointsDetailsDTO.PainPoints
            };
        }

        public static PainPointsDetailsDTO GetPainPointsDetailsDTO(PainPointsDetailsBM painPointsDetailsBM)
        {
            return new PainPointsDetailsDTO()
            {
                PainPoints = painPointsDetailsBM.PainPoints
            };
        }
    }
}
