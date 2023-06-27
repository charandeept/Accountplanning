using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class CategoryDetailsMapper
    {
        public static CategoryDetailsBM GetCategoryDetailsBM( CategoryDetailsDTO categoryDetailsDTO)
        {
            return new CategoryDetailsBM()
            {
                Id = categoryDetailsDTO.Id,
                Type = categoryDetailsDTO.Type,
            };
        }


        public static List<CategoryDetailsBM> GetCategoryDetailsBMs(List<CategoryDetailsDTO> categoryDetailsDTOs)
        {
            List<CategoryDetailsBM> list = new List<CategoryDetailsBM>();

            foreach (CategoryDetailsDTO categoryDetailsDTO in categoryDetailsDTOs)
            {
                list.Add(GetCategoryDetailsBM(categoryDetailsDTO));
            }
            return list;
        }
    }
}
