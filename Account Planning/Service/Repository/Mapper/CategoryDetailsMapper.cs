using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class CategoryDetailsMapper
    {
        public static CategoryDetailsDTO GetCategoryDetailsDTO (DataRow dataRow)
        {
            return new CategoryDetailsDTO()
            {

                Id = Convert.ToInt32(dataRow[0]),
                Type = Convert.ToString(dataRow[1]),
            };
        }

        public static List<CategoryDetailsDTO> GetCategoryDetailsDTOs (DataTable dataTable)
        {
            List<CategoryDetailsDTO> categoryDetailsDTOs = new List<CategoryDetailsDTO>();

            if (dataTable.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                categoryDetailsDTOs.Add(GetCategoryDetailsDTO(dr));
            }
            return categoryDetailsDTOs;
        }
    }
}
