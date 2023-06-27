using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class FinancialHealthHealthIndicatorMapper
    {
        public static FinancialHealthHealthIndicatorBM GetFinancialHealthHealthIndicatorBM(FinancialHealthHealthIndicatorDTO financialHealthHealthIndicatorDTO)
        {
            return new FinancialHealthHealthIndicatorBM()
            {
                CustomerId = financialHealthHealthIndicatorDTO.CustomerId,
                questionId = financialHealthHealthIndicatorDTO.questionId,
                //Id = financialHealthHealthIndicatorDTO.Id,
                OptionA = financialHealthHealthIndicatorDTO.OptionA,
                OptionB = financialHealthHealthIndicatorDTO.OptionB,
                OptionC = financialHealthHealthIndicatorDTO.OptionC,
                OptionD = financialHealthHealthIndicatorDTO.OptionD
            };
        }

        public static List<FinancialHealthHealthIndicatorBM> GetFinancialHealthHealthIndicatorBMs(List<FinancialHealthHealthIndicatorDTO> financialHealthHealthIndicatorDTOs)
        {
            List<FinancialHealthHealthIndicatorBM> financialHealthHealthIndicatorBMs = new List<FinancialHealthHealthIndicatorBM>();

            foreach (FinancialHealthHealthIndicatorDTO financialHealthHealthIndicatorDTO in financialHealthHealthIndicatorDTOs)
            {
                financialHealthHealthIndicatorBMs.Add(GetFinancialHealthHealthIndicatorBM(financialHealthHealthIndicatorDTO));
            }

            return financialHealthHealthIndicatorBMs;
        }


        public static FinancialHealthHealthIndicatorDTO GetFinancialHealthHealthIndicatorDTO(FinancialHealthHealthIndicatorBM financialHealthHealthIndicatorBM)
        {
            return new FinancialHealthHealthIndicatorDTO()
            {
                
                CustomerId = financialHealthHealthIndicatorBM.CustomerId,
                questionId = financialHealthHealthIndicatorBM.questionId,
                //Id = financialHealthHealthIndicatorBM.Id,
                OptionA = financialHealthHealthIndicatorBM.OptionA,
                OptionB = financialHealthHealthIndicatorBM.OptionB,
                OptionC = financialHealthHealthIndicatorBM.OptionC,
                OptionD = financialHealthHealthIndicatorBM.OptionD
            };
        }

        public static List<FinancialHealthHealthIndicatorDTO> GetFinancialHealthHealthIndicatorDTOs(List<FinancialHealthHealthIndicatorBM> financialHealthHealthIndicatorBMs)
        {
            List<FinancialHealthHealthIndicatorDTO> financialHealthHealthIndicatorDTOs = new List<FinancialHealthHealthIndicatorDTO>();

            foreach (FinancialHealthHealthIndicatorBM financialHealthHealthIndicatorBM in financialHealthHealthIndicatorBMs)
            {
                financialHealthHealthIndicatorDTOs.Add(GetFinancialHealthHealthIndicatorDTO(financialHealthHealthIndicatorBM));
            }

            return financialHealthHealthIndicatorDTOs;
        }

    }
}
