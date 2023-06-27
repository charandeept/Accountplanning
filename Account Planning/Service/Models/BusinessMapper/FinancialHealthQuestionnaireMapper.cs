using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class FinancialHealthQuestionnaireMapper
    {
        public static FinancialHealthQuestionnaireBM GetFinancialHealthQuestionnaireBM(FinancialHealthQuestionnaireDTO financialHealthQuestionnaireDTO)
        {
            return new FinancialHealthQuestionnaireBM()
            {
               // CustomerId = financialHealthQuestionnaireDTO.CustomerId,
                QuestionId = financialHealthQuestionnaireDTO.QuestionId,
                Question = financialHealthQuestionnaireDTO.Question,
                OptionA = financialHealthQuestionnaireDTO.OptionA,
                OptionB = financialHealthQuestionnaireDTO.OptionB,
                OptionC = financialHealthQuestionnaireDTO.OptionC,
                OptionD = financialHealthQuestionnaireDTO.OptionD,
                OptionAValue = financialHealthQuestionnaireDTO.OptionAValue,
                OptionBValue = financialHealthQuestionnaireDTO.OptionBValue,
                OptionCValue = financialHealthQuestionnaireDTO.OptionCValue,
                OptionDValue = financialHealthQuestionnaireDTO.OptionDValue,
                FormControlName = financialHealthQuestionnaireDTO.FormControlName,

            };
        }

        public static List<FinancialHealthQuestionnaireBM> GetFinancialHealthQuestionnaireBMs(List<FinancialHealthQuestionnaireDTO> financialHealthQuestionnaireDTOs)
        {
            List<FinancialHealthQuestionnaireBM> list = new List<FinancialHealthQuestionnaireBM>();

            foreach (FinancialHealthQuestionnaireDTO financialHealthQuestionnaireDTO in financialHealthQuestionnaireDTOs)
            {
                list.Add(GetFinancialHealthQuestionnaireBM(financialHealthQuestionnaireDTO));
            }
            return list;
        }
    }
}
