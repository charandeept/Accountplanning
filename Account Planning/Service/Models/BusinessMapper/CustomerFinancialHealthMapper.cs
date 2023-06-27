using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CustomerFinancialHealthMapper
    {
        public static CustomerFinancialHealthBM GetCustomerFinancialHealthBM(CustomerFinancialHealthDTO customerFinancialHealthDTO)
        {
            List<QuestionnaireBM> questionList = new List<QuestionnaireBM>();
            if (customerFinancialHealthDTO.data != null)
            {
                foreach (QuestionnaireDTO question in customerFinancialHealthDTO.data)
                {
                    questionList.Add(GetQuestionBM(question));
                }
            }

            return new CustomerFinancialHealthBM()
            {
                FinancialHealth = customerFinancialHealthDTO.FinancialHealth,
                data = questionList
            };
        }

        public static QuestionnaireBM GetQuestionBM(QuestionnaireDTO questionnaire)
        {
            return new QuestionnaireBM()
            {
                QuestionId = questionnaire.QuestionId,
                SelectedPoints = questionnaire.SelectedPoints
            };
        }

        public static CustomerFinancialHealthDTO GetCustomerFinancialHealthDTO(CustomerFinancialHealthBM customerFinancialHealthBM)
        {
            List<QuestionnaireDTO> questionList = new List<QuestionnaireDTO>();
            if (customerFinancialHealthBM.data != null)
            {
                foreach (QuestionnaireBM question in customerFinancialHealthBM.data)
                {
                    questionList.Add(GetQuestionDTO(question));
                }
            }

            return new CustomerFinancialHealthDTO()
            {
                FinancialHealth = customerFinancialHealthBM.FinancialHealth,
                data = questionList
            };
        }

        public static QuestionnaireDTO GetQuestionDTO(QuestionnaireBM questionnaire)
        {
            return new QuestionnaireDTO()
            {
                QuestionId = questionnaire.QuestionId,
                SelectedPoints = questionnaire.SelectedPoints
            };
        }
    }
}
