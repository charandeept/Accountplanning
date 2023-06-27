using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class FinancialHealthHealthIndicatorMapper
    {
        public static FinancialHealthHealthIndicatorDTO GetFinancialHealthHealthIndicatorDTO(FinancialHealthHealthIndicator financialHealthHealthIndicator)
        {
            return new FinancialHealthHealthIndicatorDTO()
            {
                CustomerId = financialHealthHealthIndicator.CustomerId,
                questionId = financialHealthHealthIndicator.questionId,
              //  Id = financialHealthHealthIndicator.Id,
                OptionA = financialHealthHealthIndicator.A,
                OptionB = financialHealthHealthIndicator.B,
                OptionC = financialHealthHealthIndicator.C,
                OptionD = financialHealthHealthIndicator.D
            };
        }

        public static List<FinancialHealthHealthIndicatorDTO> GetFinancialHealthHealthIndicatorDTOs(List<FinancialHealthHealthIndicator> financialHealthHealthIndicators)
        {
            List<FinancialHealthHealthIndicatorDTO> financialHealthHealthIndicatorDTOs = new List<FinancialHealthHealthIndicatorDTO>();

            foreach (FinancialHealthHealthIndicator financialHealthHealthIndicator in financialHealthHealthIndicators)
            {
                financialHealthHealthIndicatorDTOs.Add(GetFinancialHealthHealthIndicatorDTO(financialHealthHealthIndicator));
            }

            return financialHealthHealthIndicatorDTOs;
        }


        public static FinancialHealthHealthIndicator GetFinancialHealthHealthIndicator(FinancialHealthHealthIndicatorDTO financialHealthHealthIndicatorDTO)
        {
            return new FinancialHealthHealthIndicator()
            {
                CustomerId = financialHealthHealthIndicatorDTO.CustomerId,
                questionId = financialHealthHealthIndicatorDTO.questionId,
                //Id = financialHealthHealthIndicatorDTO.Id,
                A = financialHealthHealthIndicatorDTO.OptionA,
                B = financialHealthHealthIndicatorDTO.OptionB,
                C = financialHealthHealthIndicatorDTO.OptionC,
                D = financialHealthHealthIndicatorDTO.OptionD
            };
        }

        public static List<FinancialHealthHealthIndicator> GetFinancialHealthHealthIndicators(List<FinancialHealthHealthIndicatorDTO> financialHealthHealthIndicatorDTOs)
        {
            List<FinancialHealthHealthIndicator> financialHealthHealthIndicators = new List<FinancialHealthHealthIndicator>();

            foreach (FinancialHealthHealthIndicatorDTO financialHealthHealthIndicatorDTO in financialHealthHealthIndicatorDTOs)
            {
                financialHealthHealthIndicators.Add(GetFinancialHealthHealthIndicator(financialHealthHealthIndicatorDTO));
            }

            return financialHealthHealthIndicators;
        }
    }
}
