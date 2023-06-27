using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels
{
    public class CustomerTeamInfoBM
    {
        //public int ClientPartner { get; set; }
        public int DeliveryManager { get; set; }
        public string ClientPartnerName { get; set; }
        public string DeliveryModel { get; set; }

        // public string Timezone { get; set; }
        public int OnshoreResources { get; set; }
        public int OffshoreResources { get; set; }
        public int NearShore { get; set; }
    }
}
