using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CustomerQuestionnaireMapper
    {
        public CustomerQuestionnaire GetCustomerQuestionnare (CustomerQuestionnaireDTO customerQuestionnaireDTO)
        {
            return new CustomerQuestionnaire()
            {
                //Id = customerQuestionnaireDTO.Id,
                QuestionId=customerQuestionnaireDTO.QuestionId,
                Points = customerQuestionnaireDTO.Points,
            };
        }

        public CustomerQuestionnaireDTO GetQuestionnaireDTO (CustomerQuestionnaire customerQuestionnaire)
        {
            return new CustomerQuestionnaireDTO()
            {
                //Id = customerQuestionnaire.Id,
                QuestionId = customerQuestionnaire.QuestionId,
                Points = customerQuestionnaire.Points,
            };
        }
    }
}
