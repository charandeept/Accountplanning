using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CustomerEngagementHealthMapper
    {
        public static CustomerEngagementHealthBM GetCustomerEngagementHealthBM(CustomerEngagementHealthDTO customerEngagementHealthDTO)
        {
            List<QuestionnaireBM> questionList = new List<QuestionnaireBM>();
            if (customerEngagementHealthDTO.data != null)
            {
                foreach (QuestionnaireDTO question in customerEngagementHealthDTO.data)
                {
                    questionList.Add(GetQuestionBM(question));
                }
            }

            return new CustomerEngagementHealthBM()
            {
                EngagementHealth = customerEngagementHealthDTO.EngagementHealth,
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


        public static CustomerEngagementHealthDTO GetCustomerEngagementHealthDTO(CustomerEngagementHealthBM customerEngagementHealthBM)
        {
            List<QuestionnaireDTO> questionList = new List<QuestionnaireDTO>();
            if (customerEngagementHealthBM.data != null)
            {
                foreach (QuestionnaireBM question in customerEngagementHealthBM.data)
                {
                    questionList.Add(GetQuestionDTO(question));
                }
            }

            return new CustomerEngagementHealthDTO()
            {
                EngagementHealth =customerEngagementHealthBM.EngagementHealth,
                data  = questionList
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
