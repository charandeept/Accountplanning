using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels
{
    public class OpportunitiesTable
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoadMapId { get; set; }
        public string PainPoints { get; set; }
        public int CategoryId { get; set; }
       // public bool IsBookMarked { get; set; }
       
    }
}
