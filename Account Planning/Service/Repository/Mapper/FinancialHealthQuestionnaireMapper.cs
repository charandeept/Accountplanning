using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    
    public class FinancialHealthQuestionnaireMapper
    {
        public static FinancialHealthQuestionnaireDTO GetFinancialHealthQuestionnaireDTO(DataRow financialHealthQuestionnaire)
        {
            return new FinancialHealthQuestionnaireDTO()
            {
                //CustomerId = Convert.ToInt32(financialHealthQuestionnaire[0]),
                QuestionId = Convert.ToInt32(financialHealthQuestionnaire[0]),
                Question = Convert.ToString(financialHealthQuestionnaire[1]),
                OptionA = Convert.ToString(financialHealthQuestionnaire[2]),
                OptionB = Convert.ToString(financialHealthQuestionnaire[3]),
                OptionC = Convert.ToString(financialHealthQuestionnaire[4]),
                OptionD = Convert.ToString(financialHealthQuestionnaire[5]),
                OptionAValue = Convert.ToInt32(financialHealthQuestionnaire[6]),
                OptionBValue = Convert.ToInt32(financialHealthQuestionnaire[7]),
                OptionCValue = Convert.ToInt32(financialHealthQuestionnaire[8]),
                OptionDValue = Convert.ToInt32(financialHealthQuestionnaire[9]),
                FormControlName = Convert.ToString(financialHealthQuestionnaire[10]),
            };



        }



        public static List<FinancialHealthQuestionnaireDTO> GetFinancialHealthQuestionnaireDTOs(DataTable financialHealthQuestionnaireTable)
        {
            List<FinancialHealthQuestionnaireDTO> financialHealthQuestionnaire = new List<FinancialHealthQuestionnaireDTO>();

            if (financialHealthQuestionnaireTable.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow fhq in financialHealthQuestionnaireTable.Rows)
            {
                financialHealthQuestionnaire.Add(GetFinancialHealthQuestionnaireDTO(fhq));
            }
            return financialHealthQuestionnaire;
        }



        public static FinancialHealthQuestionnaire GetEnagagementHealthQuestionnaire(FinancialHealthQuestionnaireDTO financialHealthQuestionnaireDTO)
        {
            return new FinancialHealthQuestionnaire()
            {
               // CustomerId = financialHealthQuestionnaireDTO.CustomerId,
                Question = financialHealthQuestionnaireDTO.Question,
                OptionA = financialHealthQuestionnaireDTO.OptionA,
                OptionB = financialHealthQuestionnaireDTO.OptionB,
                OptionC = financialHealthQuestionnaireDTO.OptionC,
                OptionD = financialHealthQuestionnaireDTO.OptionD,
                OptionAValue = financialHealthQuestionnaireDTO.OptionAValue,
                OptionBValue = financialHealthQuestionnaireDTO.OptionBValue,
                OptionCValue = financialHealthQuestionnaireDTO.OptionCValue,
                OptionDValue = financialHealthQuestionnaireDTO.OptionDValue
            };
        }
    }
}
