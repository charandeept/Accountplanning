using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CustomerFinancialHealthMapper
    {
        public static CustomerFinancialHealthDTO GetCustomerFinancialHealthDTO(DataTable customerFinancialHealth)
        {
            if(customerFinancialHealth.Rows.Count == 0)
            {
                return null;
            }

            CustomerFinancialHealthDTO financialHealthDetails = new CustomerFinancialHealthDTO();
            financialHealthDetails.data = new List<QuestionnaireDTO>();

            foreach (DataRow row in customerFinancialHealth.Rows)
            {
                financialHealthDetails.FinancialHealth = Convert.ToInt32(row[1]);
                QuestionnaireDTO question = new QuestionnaireDTO();
                question.QuestionId = Convert.ToInt32(row[2]);
                question.SelectedPoints = Convert.ToInt32(row[3]);

                financialHealthDetails.data.Add(question);
            }
            return financialHealthDetails;
        }

        public static CustomerFinancialHealth GetCustomerFinancialHealth(CustomerFinancialHealthDTO customerFinancialHealthDTO)
        {
            return new CustomerFinancialHealth()
            {
                FinancialHealth = customerFinancialHealthDTO.FinancialHealth,
            };
        }

        public static CustomerFinancialHealthDTO GetCustomerFinancialHealthDTOFromCustomerTable(CustomerInfoTable customerInfoTable)
        {
            return new CustomerFinancialHealthDTO()
            {
                //Id = customerInfoTable.Id,
                FinancialHealth=customerInfoTable.FinancialHealth
            };
        }
    }
}
