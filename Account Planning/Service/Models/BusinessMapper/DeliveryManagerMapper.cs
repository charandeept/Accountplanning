using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class DeliveryManagerMapper
    {
        public static DeliveryManagerBM GetDeliveryManagerBM(DeliveryManagerDTO deliveryManagerDTO)
        {
            return new DeliveryManagerBM()
            {
                Id = deliveryManagerDTO.Id,
                DeliveryManager = deliveryManagerDTO.DeliveryManager
            };
        }

        public static List<DeliveryManagerBM> GetDeliveryManagerBMs(List<DeliveryManagerDTO> headQuartersDTOs)
        {
            List<DeliveryManagerBM> list = new List<DeliveryManagerBM>();

            foreach (DeliveryManagerDTO deliveryManagerDTO in headQuartersDTOs)
            {
                list.Add(GetDeliveryManagerBM(deliveryManagerDTO));
            }
            return list;
        }
    }
}
