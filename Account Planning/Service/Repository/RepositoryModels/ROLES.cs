using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels
{
    public class ROLES
    {
        [Key]
        public int RoleId { get; set; }
        public int OpportunitiesId { get; set; }
        public int CustomerId { get; set; }
        public string RoleTitle { get; set; }
        public int CategoryId { get; set; }
       // public string Category { get; set; }
        public int NoOfRoles { get; set; }
        public string Skills { get; set; }
        public DateTime? PostedDate { get; set; }
        public string Location { get; set; }
        public string RoleDescription { get; set; }
        public bool IsBookMarked { get; set; }
        public int MinExperience { get; set; }
        public int MaxExperience { get; set; }

    }
}
