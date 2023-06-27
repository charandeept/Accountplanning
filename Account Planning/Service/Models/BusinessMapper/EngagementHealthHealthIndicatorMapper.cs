using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class EngagementHealthHealthIndicatorMapper
    {
        
        public static EngagementHealthHealthIndicatorBM GetHealthHealthIndicatorBM(EngagementHealthHealthIndicatorDTO engagementHealthHealthIndicatorDTO)
        {
            return new EngagementHealthHealthIndicatorBM()
            {
                CustomerId = engagementHealthHealthIndicatorDTO.CustomerId,
                questionId = engagementHealthHealthIndicatorDTO.questionId,
                OptionA = engagementHealthHealthIndicatorDTO.OptionA,
                OptionB = engagementHealthHealthIndicatorDTO.OptionB,
                OptionC = engagementHealthHealthIndicatorDTO.OptionC,
                OptionD = engagementHealthHealthIndicatorDTO.OptionD,
               // FormControlName = engagementHealthHealthIndicatorDTO.FormControlName
            };
        }

        public static List<EngagementHealthHealthIndicatorBM> GetEngagementHealthHealthIndicatorBMs(List<EngagementHealthHealthIndicatorDTO> engagementHealthHealthIndicatorDTOs)
        {
            List<EngagementHealthHealthIndicatorBM> engagementHealthHealthIndicatorBMs = new List<EngagementHealthHealthIndicatorBM>();

            foreach(EngagementHealthHealthIndicatorDTO engagementHealthHealthIndicatorDTO in engagementHealthHealthIndicatorDTOs)
            {
                engagementHealthHealthIndicatorBMs.Add(GetHealthHealthIndicatorBM(engagementHealthHealthIndicatorDTO));
            }

            return engagementHealthHealthIndicatorBMs;
        }


        public static EngagementHealthHealthIndicatorDTO GetHealthHealthIndicatorDTO(EngagementHealthHealthIndicatorBM engagementHealthHealthIndicatorBM)
        {
            return new EngagementHealthHealthIndicatorDTO()
            {
                CustomerId = engagementHealthHealthIndicatorBM.CustomerId,
                questionId = engagementHealthHealthIndicatorBM.questionId,
                OptionA = engagementHealthHealthIndicatorBM.OptionA,
                OptionB = engagementHealthHealthIndicatorBM.OptionB,
                OptionC = engagementHealthHealthIndicatorBM.OptionC,
                OptionD = engagementHealthHealthIndicatorBM.OptionD,
               // FormControlName = engagementHealthHealthIndicatorBM.FormControlName
            };
        }

        public static List<EngagementHealthHealthIndicatorDTO> GetEngagementHealthHealthIndicatorDTOs(List<EngagementHealthHealthIndicatorBM> engagementHealthHealthIndicatorBMs)
        {
            List<EngagementHealthHealthIndicatorDTO> engagementHealthHealthIndicatorDTOs = new List<EngagementHealthHealthIndicatorDTO>();

            foreach (EngagementHealthHealthIndicatorBM engagementHealthHealthIndicatorBM in engagementHealthHealthIndicatorBMs)
            {
                engagementHealthHealthIndicatorDTOs.Add(GetHealthHealthIndicatorDTO(engagementHealthHealthIndicatorBM));
            }

            return engagementHealthHealthIndicatorDTOs;
        }



    }
}
