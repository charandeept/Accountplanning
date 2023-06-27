using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Models
{
    public class CustomerUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CustomerId { get; set; }

        public virtual CustomerBusinessInfo Customer { get; set; }
        public virtual ICollection<OrgHierarchy> OrgHierarchy { get; set; }
    }

}
