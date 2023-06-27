namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ServiceLineMapper
    {
        public static ServiceLineBM GetServiceLineBM(ServiceLineDTO serviceLineDTO)
        {
            return new ServiceLineBM()
            {
                Id = serviceLineDTO.Id,
                ServiceLine = serviceLineDTO.ServiceLine
            };
        }

        public static List<ServiceLineBM> GetServiceLineBMs(List<ServiceLineDTO> serviceLineDTOs)
        {
            List<ServiceLineBM> list = new List<ServiceLineBM>();

            foreach (ServiceLineDTO serviceLineDTO in serviceLineDTOs)
            {
                list.Add(GetServiceLineBM(serviceLineDTO));
            }
            return list;
        }
    }
}
