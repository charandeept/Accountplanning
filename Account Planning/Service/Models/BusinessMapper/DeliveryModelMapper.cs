using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessMapper
{
    public class DeliveryModelMapper
    {
        public static DeliveryModelBM GetDeliveryModelBM(DeliveryModelDTO deliveryModelDTO)
        {
            return new DeliveryModelBM()
            {
                Id = deliveryModelDTO.Id,
                DeliveryModel= deliveryModelDTO.DeliveryModel
            };
        }

        public static List<DeliveryModelBM> GetDeliveryModelBMs(List<DeliveryModelDTO> deliveryModelDTOs)
        {
            List<DeliveryModelBM> list = new List<DeliveryModelBM>();

            foreach (DeliveryModelDTO deliveryModelDTO in deliveryModelDTOs)
            {
                list.Add(GetDeliveryModelBM(deliveryModelDTO));
            }
            return list;
        }
    }
}
