namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    using System;
    public class UsersTableDTO
    {
        public int InnovaId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
        public string IsActiveUI { get; set; }
        public string ModifiedByUI { get; set; }
        public string ModifiedDateUI { get; set; }



        public int Id { get; set; }
        public int UserRoleId { get; set; }
        public bool IsActive { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
