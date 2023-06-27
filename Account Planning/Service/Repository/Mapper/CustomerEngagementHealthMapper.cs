using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CustomerEngagementHealthMapper
    {
        public static CustomerEngagementHealthDTO GetCustomerEngagementHealthDTO(DataTable customerEngagementHealth)
        {
            if (customerEngagementHealth.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                CustomerEngagementHealthDTO engagementHealthDetails = new CustomerEngagementHealthDTO();
                engagementHealthDetails.data = new List<QuestionnaireDTO>();

                foreach (DataRow row in customerEngagementHealth.Rows)
                {
                    engagementHealthDetails.EngagementHealth = Convert.ToInt32(row[1]);
                    QuestionnaireDTO question = new QuestionnaireDTO();
                    question.QuestionId = Convert.ToInt32(row[2]);
                    question.SelectedPoints = Convert.ToInt32(row[3]);

                    engagementHealthDetails.data.Add(question);
                }
                return engagementHealthDetails;

            }

        }

        public static CustomerEngagementHealth GetcustomerEngagementHealth(CustomerEngagementHealthDTO customerEngagementHealthDTO)
        {
            return new CustomerEngagementHealth()
            {
                EngagementHealth = customerEngagementHealthDTO.EngagementHealth
            };
        }

        public static CustomerEngagementHealthDTO GetCustomerEngagementHealtDTOFromCustomerTable(CustomerInfoTable customerInfoTable)
        {
            return new CustomerEngagementHealthDTO()
            {
                EngagementHealth = customerInfoTable.EngagementHealth
            };

        }












    }
}
