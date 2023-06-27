using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
        public class IndustryMapper
        {
            public static IndustryBM GetIndustryBM(IndustryDTO industryDTO)
            {
                return new IndustryBM()
                {
                    Id = industryDTO.Id,
                    Industry = industryDTO.Industry
                };
            }

            public static List<IndustryBM> GetIndustryBMs(List<IndustryDTO> industryDTOs)
            {
                List<IndustryBM> list = new List<IndustryBM>();

                foreach (IndustryDTO industryDTO in industryDTOs)
                {
                    list.Add(GetIndustryBM(industryDTO));
                }
                return list;
            }
        }
    }

