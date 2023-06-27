using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{

    public class EngagementHealthQuestionnaireMapper
    {
        public static EngagementHealthQuestionnaireDTO GetEnagagementHealthQuestionnaireDTO(DataRow enagagementHealthQuestionnaire)
        {
            return new EngagementHealthQuestionnaireDTO()
            {
                //CustomerId = Convert.ToInt32(enagagementHealthQuestionnaire[0]),
                QuestionId = Convert.ToInt32(enagagementHealthQuestionnaire[0]),
                Question = Convert.ToString(enagagementHealthQuestionnaire[1]),
                OptionA = Convert.ToString(enagagementHealthQuestionnaire[2]),
                OptionB = Convert.ToString(enagagementHealthQuestionnaire[3]),
                OptionC = Convert.ToString(enagagementHealthQuestionnaire[4]),
                OptionD = Convert.ToString(enagagementHealthQuestionnaire[5]),
                OptionAValue = Convert.ToInt32(enagagementHealthQuestionnaire[6]),
                OptionBValue = Convert.ToInt32(enagagementHealthQuestionnaire[7]),
                OptionCValue = Convert.ToInt32(enagagementHealthQuestionnaire[8]),
                OptionDValue = Convert.ToInt32(enagagementHealthQuestionnaire[9]),
                FormControlName = Convert.ToString(enagagementHealthQuestionnaire[10]),
    };



        }



        public static List<EngagementHealthQuestionnaireDTO> GetEngagementHealthQuestionnaireDTOs(DataTable engagementHealthQuestionnaireTable)
        {
            List<EngagementHealthQuestionnaireDTO> engagementHealthQuestionnaire = new List<EngagementHealthQuestionnaireDTO>();

            if(engagementHealthQuestionnaireTable.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow ehq in engagementHealthQuestionnaireTable.Rows)
            {
                engagementHealthQuestionnaire.Add(GetEnagagementHealthQuestionnaireDTO(ehq));
            }

            return engagementHealthQuestionnaire;
        }




        public static EngagementHealthQuestionnaire GetEnagagementHealthQuestionnaire(EngagementHealthQuestionnaireDTO enagagementHealthQuestionnaireDTO)
        {
            return new EngagementHealthQuestionnaire()
            {
                //CustomerId = enagagementHealthQuestionnaireDTO.CustomerId,
                QuestionId = enagagementHealthQuestionnaireDTO.QuestionId,
                Question = enagagementHealthQuestionnaireDTO.Question,
                OptionA = enagagementHealthQuestionnaireDTO.OptionA,
                OptionB = enagagementHealthQuestionnaireDTO.OptionB,
                OptionC = enagagementHealthQuestionnaireDTO.OptionC,
                OptionD = enagagementHealthQuestionnaireDTO.OptionD,
                OptionAValue = enagagementHealthQuestionnaireDTO.OptionAValue,
                OptionBValue = enagagementHealthQuestionnaireDTO.OptionBValue,
                OptionCValue = enagagementHealthQuestionnaireDTO.OptionCValue,
                OptionDValue = enagagementHealthQuestionnaireDTO.OptionDValue,
              //  FormControlName = enagagementHealthQuestionnaireDTO.FormControlName,
            };
        }



    }
}
