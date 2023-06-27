using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class FinancialToengagementMapper
    {

        public static EngagementHealthHealthIndicatorDTO GetEngagementHealthHealthIndicatorDTO(FinancialHealthHealthIndicatorDTO y )
        {
            return new EngagementHealthHealthIndicatorDTO()
            {
                //CustomerId = y.CustomerId,
                questionId = y.questionId,
                OptionA = y.OptionA,
                OptionB = y.OptionB,
                OptionC = y.OptionC,
                OptionD = y.OptionD
            };
        }

        public static List<EngagementHealthHealthIndicatorDTO> GetEngagementHealthHealthIndicatorDTOs(List<FinancialHealthHealthIndicatorDTO> financialhealth)
        {
            List<EngagementHealthHealthIndicatorDTO> list = new List<EngagementHealthHealthIndicatorDTO>();


            foreach(var x in financialhealth)
            {
                list.Add(GetEngagementHealthHealthIndicatorDTO(x));

            }

            return list;
        }

        public static FinancialHealthHealthIndicatorDTO GetFinancialHealthHealthIndicatorDTO(EngagementHealthHealthIndicatorDTO y)
        {
            return new FinancialHealthHealthIndicatorDTO()
            {
               // CustomerId = y.CustomerId,
                questionId = y.questionId,
                OptionA = y.OptionA,
                OptionB = y.OptionB,
                OptionC = y.OptionC,
                OptionD = y.OptionD
            };
        }

        public static List<FinancialHealthHealthIndicatorDTO> GetFinancialHealthHealthIndicatorDTOs(List<EngagementHealthHealthIndicatorDTO> engagement)
        {
            List<FinancialHealthHealthIndicatorDTO> list = new List<FinancialHealthHealthIndicatorDTO>();


            foreach (var x in engagement)
            {
                list.Add(GetFinancialHealthHealthIndicatorDTO(x));
            }

            return list;
        }
    }
}
