using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class ClientDetailsDTO
    {

        //public int ClientPartnerId { get; set; }
        public string ClientPartnerName { get; set; }     
        public int DeliveryManagerId { get; set; }
        public string DeliveryManager { get; set; }
        public string DeliveryModel { get; set; }
        public int TimeZoneId { get; set; }
        public string Timezone { get; set; }
        public int OnshoreResources { get; set; }
        public int OffshoreResources { get; set; }
        public int NearShore { get; set; }
        public string ProjectEndDate { get; set; }
        
    }
}
