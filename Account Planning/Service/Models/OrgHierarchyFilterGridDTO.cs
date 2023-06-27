using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models
{
    public class OrgHierarchyFilterGridDTO
    { 
        public int CustomerId { get; set; }
        public List<filterlist> Filterconditions { get; set; }
        public string SearchText { get; set; }
        public string OrderColumn { get; set; }
        public string OrderType { get; set; }
    }
}
