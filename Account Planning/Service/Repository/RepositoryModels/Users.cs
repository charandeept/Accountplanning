namespace Com.ACSCorp.AccountPlanning.Service.Repository.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Users
    { 
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool IsActive { get; set; }
        public int UserRoleId { get; set; }
        public int InnovaId { get; set; }

        public string Designation { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
