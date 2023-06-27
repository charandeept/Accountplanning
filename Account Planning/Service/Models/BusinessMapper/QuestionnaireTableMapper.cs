using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class QuestionnaireTableMapper
    {
        public QuestionnaireTableDTO GetQuestionnaireTableDTO (QuestionnaireTableBM questionnaireTableBM)
        {
            return new QuestionnaireTableDTO()
            {
                QuestionId = questionnaireTableBM.QuestionId,
                OptionA = questionnaireTableBM.OptionA,
                OptionB=questionnaireTableBM.OptionB,
                OptionC=questionnaireTableBM.OptionC,
                OptionD=questionnaireTableBM.OptionD,
            };
        }

        public QuestionnaireTableBM GetQuestionnaireTableBM (QuestionnaireTableDTO questionnaireTableDTO)
        {
            return new QuestionnaireTableBM()
            {
                QuestionId = questionnaireTableDTO.QuestionId,
                OptionA = questionnaireTableDTO.OptionA,
                OptionB = questionnaireTableDTO.OptionB,
                OptionC = questionnaireTableDTO.OptionC,
                OptionD = questionnaireTableDTO.OptionD,
            };
        }
             
    }
}
