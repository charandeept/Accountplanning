using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Models
{
    public class InfluencerKdm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrgHierarchy> OrgHierarchy { get; set; }
    }
}

