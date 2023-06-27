using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Models
{
     public class CustomerTeamInfo
     {
        public int Id { get; set; }
        //public int ClientPartnerId { get; set; }
        public int DeliveryManagerId { get; set; }
        public string DeliveryModel { get; set; }
        public string ClientPartnerName { get; set; }

        //public string Timezone { get; set; }
        public int OnshoreResources { get; set; }
        public int OffshoreResources { get; set; }
        public int NearShoreResources { get; set; }

     }
}
