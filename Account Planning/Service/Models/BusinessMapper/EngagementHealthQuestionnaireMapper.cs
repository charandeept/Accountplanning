using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System.Collections.Generic;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class EngagementHealthQuestionnaireMapper
    {
        
            public static EngagementHealthQuestionnaireBM GetEngagementHealthQuestionnaireBM(EngagementHealthQuestionnaireDTO engagementHealthQuestionnaireDTO)
            {
                return new EngagementHealthQuestionnaireBM()
                {
                  //  CustomerId = engagementHealthQuestionnaireDTO.CustomerId,
                    QuestionId = engagementHealthQuestionnaireDTO.QuestionId,
                    Question=engagementHealthQuestionnaireDTO.Question,
                    OptionA=engagementHealthQuestionnaireDTO.OptionA,
                    OptionB=engagementHealthQuestionnaireDTO.OptionB,
                    OptionC=engagementHealthQuestionnaireDTO.OptionC,
                    OptionD=engagementHealthQuestionnaireDTO.OptionD,
                    OptionAValue = engagementHealthQuestionnaireDTO.OptionAValue,
                    OptionBValue = engagementHealthQuestionnaireDTO.OptionBValue,
                    OptionCValue = engagementHealthQuestionnaireDTO.OptionCValue,
                    OptionDValue = engagementHealthQuestionnaireDTO.OptionDValue,
                    FormControlName = engagementHealthQuestionnaireDTO.FormControlName,

                };
            }

            public static List<EngagementHealthQuestionnaireBM> GetEngagementHealthQuestionnaireBMs(List<EngagementHealthQuestionnaireDTO> engagementHealthQuestionnaireDTOs)
            {
                List<EngagementHealthQuestionnaireBM> list = new List<EngagementHealthQuestionnaireBM>();

                foreach (EngagementHealthQuestionnaireDTO engagementHealthQuestionnaireDTO in engagementHealthQuestionnaireDTOs)
                {
                    list.Add(GetEngagementHealthQuestionnaireBM(engagementHealthQuestionnaireDTO));
                }
                return list;
            }
        
    }
}
