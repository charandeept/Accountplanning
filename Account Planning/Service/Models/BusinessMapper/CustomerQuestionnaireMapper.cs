using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CustomerQuestionnaireMapper
    {
        public CustomerQuestionnaireBM GetCustomerQuestionnaireBM(CustomerQuestionnaireDTO customerQuestionnaireDTO)
        {
            return new CustomerQuestionnaireBM()
            {
                Id = customerQuestionnaireDTO.Id,
                QuestionId = customerQuestionnaireDTO.QuestionId,
                Points = customerQuestionnaireDTO.Points,

            };
        }


        public CustomerQuestionnaireDTO GetCustomerQuestionnaireDTO (CustomerQuestionnaireBM customerQuestionnaireBM)
        {
            return new CustomerQuestionnaireDTO()

            {
                Id = customerQuestionnaireBM.Id,
                QuestionId= customerQuestionnaireBM.QuestionId,
                Points= customerQuestionnaireBM.Points,
            };
        }
    }
}
