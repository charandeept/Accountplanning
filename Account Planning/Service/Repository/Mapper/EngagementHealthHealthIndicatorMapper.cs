using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class EngagementHealthHealthIndicatorMapper
    {
        public static EngagementHealthHealthIndicatorDTO GetEngagementHealthHealthIndicatorDTO(EngagementHealthHealthIndicator engagementHealthHealthIndicator)
        {
            return new EngagementHealthHealthIndicatorDTO()
            {
                CustomerId = engagementHealthHealthIndicator.CustomerId,
                questionId = engagementHealthHealthIndicator.questionId,
                OptionA = engagementHealthHealthIndicator.A,
                OptionB = engagementHealthHealthIndicator.B,
                OptionC = engagementHealthHealthIndicator.C,
                OptionD = engagementHealthHealthIndicator.D,
                //FormControlName = engagementHealthHealthIndicator.FormControlName,
            };
        }

        public static List<EngagementHealthHealthIndicatorDTO> GetEngagementHealthHealthIndicatorDTOs( List<EngagementHealthHealthIndicator> engagementHealthHealthIndicators)
        {
            List<EngagementHealthHealthIndicatorDTO> engagementHealthHealthIndicatorDTOs = new List<EngagementHealthHealthIndicatorDTO>();

            foreach (EngagementHealthHealthIndicator engagementHealthHealthIndicator in engagementHealthHealthIndicators)
            {
                engagementHealthHealthIndicatorDTOs.Add(GetEngagementHealthHealthIndicatorDTO(engagementHealthHealthIndicator));
            }

            return engagementHealthHealthIndicatorDTOs;
        }


        public static EngagementHealthHealthIndicator GetHealthHealthIndicator(EngagementHealthHealthIndicatorDTO engagementHealthHealthIndicatorDTO)
        {
            return new EngagementHealthHealthIndicator()
            {
                CustomerId = engagementHealthHealthIndicatorDTO.CustomerId,
                questionId = engagementHealthHealthIndicatorDTO.questionId,
                A = engagementHealthHealthIndicatorDTO.OptionA,
                B = engagementHealthHealthIndicatorDTO.OptionB,
                C = engagementHealthHealthIndicatorDTO.OptionC,
                D = engagementHealthHealthIndicatorDTO.OptionD,
              //  FormControlName=engagementHealthHealthIndicatorDTO.FormControlName
            };
        }

        public static List<EngagementHealthHealthIndicator> GetEngagementHealthHealthIndicators(List<EngagementHealthHealthIndicatorDTO> engagementHealthHealthIndicatorDTOs)
        {
            List<EngagementHealthHealthIndicator> engagementHealthHealthIndicators = new List<EngagementHealthHealthIndicator>();

            foreach (EngagementHealthHealthIndicatorDTO engagementHealthHealthIndicatorDTO in engagementHealthHealthIndicatorDTOs)
            {
                engagementHealthHealthIndicators.Add(GetHealthHealthIndicator(engagementHealthHealthIndicatorDTO));
            }

            return engagementHealthHealthIndicators;
        }
    }
}
