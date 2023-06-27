//using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using Microsoft.EntityFrameworkCore;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Context
{
    public class AccountPlanningContext : DbContext
    {
        public AccountPlanningContext(DbContextOptions<AccountPlanningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerVendor> CustomerVendor { get; set; }

        public virtual DbSet<Vendor> Vendor { get; set; }

        public virtual DbSet<CustomerVendorService> CustomerVendorServices { get; set; }

        public virtual DbSet<CustomerTeamInfo> CustomerTeamInfo { get; set; }

        //public virtual DbSet<CustomerInfoTable> CustomerInfoTable { get; set; }

        public virtual DbSet<CustomerFinancialHealth> CustomerFinancialHealth { get; set; }

        public virtual DbSet<CustomerMoodDetails> CustomerMoodDetails { get; set; }
        public virtual DbSet<CustomerQuestionnaire> CustomerQuestionnaire { get; set; }

        public virtual DbSet<Designation> Designations { get; set; }

        public virtual DbSet<OrgHierarchy> OrgHierarchy { get; set; }

        public DbSet<CustomerInfoTable> CustomerBusinessInfo { get; set; }

        public virtual DbSet<CustomerUser> CustomerUser { get; set; }

        public virtual DbSet<InfluencerKdm> InfluencerKdm { get; set; }


        //public virtual DbSet<Users> LOGIN { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<EngagementHealthHealthIndicator> HealthIndicator { get; set; }





        // public DbSet<HealthIndicator> HealthIndicator { get; set; }


        //public DbSet<FinancialHealthHealthIndicator> HealthIndicator { get; set; }

        public virtual DbSet<HealthHistory> HealthHistory { get; set; }

        public virtual DbSet<RoadMapDetails> RoadMap { get; set; }

        public virtual DbSet<OpportunitiesTable> Opportunities { get; set; }

        public virtual DbSet<ROLES> ROLES { get; set; }

        public virtual DbSet<Enablers> Enablers { get; set; }
        public virtual DbSet<EnablerType> EnablerType { get; set; }


    }
}

