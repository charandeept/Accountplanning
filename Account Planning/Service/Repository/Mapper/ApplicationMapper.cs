using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.Models;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using Com.ACSCorp.AccountPlanning.Service.Repository.RepositoryModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Globalization;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<JsonPatchDocument<CustomerEngagementHealthDTO>, JsonPatchDocument<CustomerInfoTable>>().ReverseMap();
            CreateMap<Operation<CustomerEngagementHealthDTO>, Operation<CustomerInfoTable>>().ReverseMap();

            CreateMap<JsonPatchDocument<CustomerMoodDetailsDTO>, JsonPatchDocument<CustomerInfoTable>>().ReverseMap();
            CreateMap<Operation<CustomerMoodDetailsDTO>, Operation<CustomerInfoTable>>().ReverseMap();



            CreateMap<JsonPatchDocument<CustomerBusinessInfoDTO>, JsonPatchDocument<CustomerInfoTable>>().ReverseMap();
            CreateMap<Operation<CustomerBusinessInfoDTO>, Operation<CustomerInfoTable>>().ReverseMap();



            CreateMap<JsonPatchDocument<CSATDetailsDTO>, JsonPatchDocument<CustomerInfoTable>>().ReverseMap();
            CreateMap<Operation<CSATDetailsDTO>, Operation<CustomerInfoTable>>().ReverseMap();



            CreateMap<JsonPatchDocument<CustomerEngagementHealthDTO>, JsonPatchDocument<CustomerInfoTable>>().ReverseMap();
            CreateMap<Operation<CustomerEngagementHealthDTO>, Operation<CustomerInfoTable>>().ReverseMap();



            CreateMap<JsonPatchDocument<CustomerMoodDetailsDTO>, JsonPatchDocument<CustomerInfoTable>>().ReverseMap();
            CreateMap<Operation<CustomerMoodDetailsDTO>, Operation<CustomerInfoTable>>().ReverseMap();


            CreateMap<JsonPatchDocument<CustomerFinancialHealthDTO>, JsonPatchDocument<CustomerInfoTable>>().ReverseMap();
            CreateMap<Operation<CustomerFinancialHealthDTO>, Operation<CustomerInfoTable>>().ReverseMap();

            CreateMap<JsonPatchDocument<CustomerTeamInfoDTO>, JsonPatchDocument<CustomerInfoTable>>().ReverseMap();
            CreateMap<Operation<CustomerTeamInfoDTO>, Operation<CustomerInfoTable>>().ReverseMap();

            CreateMap<System.Data.DataRow, DesignationDTO>()
                    .ForMember(m => m.ID, s => s.MapFrom(s => (int)s.ItemArray[0]))
                    .ForMember(m => m.Name, s => s.MapFrom(s => s.ItemArray[1].ToString()))
                    .ReverseMap();

            CreateMap<System.Data.DataRow, InnovaUserDTO>()
                               .ForMember(m => m.ID, s => s.MapFrom(s => (int)s.ItemArray[0]))
                               .ForMember(m => m.Name, s => s.MapFrom(s => s.ItemArray[1].ToString()))
                               .ReverseMap();

            CreateMap<System.Data.DataRow, OrgHierarchyDTO>()
               .ForMember(m => m.Id, s => s.MapFrom(s => (int)s.ItemArray[0]))
               .ForMember(m => m.UserId, s => s.MapFrom(s => (int?)s.ItemArray[1]))
               .ForMember(m => m.Name, s => s.MapFrom(s => s.ItemArray[2].ToString()))
               .ForMember(m => m.Designation, s => s.MapFrom(s => s.ItemArray[3].ToString()))
               .ForMember(m => m.InfluencerOrKdm_Name, s => s.MapFrom(s => s.ItemArray[4].ToString()))
               .ForMember(m => m.InfluencerKdmId, s => s.MapFrom(s => (int?)s.ItemArray[5]))
               .ForMember(m => m.EngagementLevelId, s => s.MapFrom(s => s.ItemArray[6] == DBNull.Value ? null : (int?)s.ItemArray[6]))
               .ForMember(m => m.EngagementLevel_Name, s => s.MapFrom(s => s.ItemArray[7].ToString()))
               .ForMember(m => m.InnovaDmid, s => s.MapFrom(s => (int?)s.ItemArray[8]))
               .ForMember(m => m.InnovaDM_Name, s => s.MapFrom(s => s.ItemArray[9].ToString()))
               .ForMember(m => m.ReportsTO_Name, s => s.MapFrom(s => s.ItemArray[10] == DBNull.Value ? "N/A" : s.ItemArray[10].ToString()))
               .ForMember(m => m.ReportsToId, s => s.MapFrom(s => s.ItemArray[11] == DBNull.Value ? 0 : (int?)s.ItemArray[11]))
               .ForMember(m => m.CustomerId, s => s.MapFrom(s => (int?)s.ItemArray[12]))
               .ForMember(m => m.Persona, s => s.MapFrom(s => s.ItemArray[13].ToString()))
               .ForMember(m => m.RoleDescription, s => s.MapFrom(s => s.ItemArray[14].ToString()))
               .ForMember(m => m.LinkedInUrl, s => s.MapFrom(s => s.ItemArray[15].ToString()))
               .ForMember(m => m.Gender, s => s.MapFrom(s => s.ItemArray[16]))
               .ForMember(m => m.UpdateBy, s => s.MapFrom(s => s.ItemArray[17] == DBNull.Value ? null : (int?)s.ItemArray[17]))
               .ForMember(m => m.UpdatedAt, s => s.MapFrom(s => s.ItemArray[18] == DBNull.Value ? null : (DateTime?)s.ItemArray[18]))
               .ReverseMap();

            CreateMap<System.Data.DataRow, InfluencerDTO>()
                .ForMember(m => m.Id, s => s.MapFrom(s => (int)s.ItemArray[0]))
                .ForMember(m => m.Name, s => s.MapFrom(s => s.ItemArray[1].ToString()))
                .ReverseMap();

            CreateMap<System.Data.DataRow, CustomerUserDTO>()
                .ForMember(m => m.Id, s => s.MapFrom(s => (int)s.ItemArray[0]))
                .ForMember(m => m.Name, s => s.MapFrom(s => s.ItemArray[1].ToString()))
                .ReverseMap();
            CreateMap<System.Data.DataRow, EngagementDTO>()
                .ForMember(m => m.ID, s => s.MapFrom(s => s.ItemArray[0]))
                .ForMember(m => m.Name, s => s.MapFrom(s => s.ItemArray[1].ToString()))
                .ReverseMap();

            CreateMap<InfluencerKdm, InfluencerDTO>().ReverseMap();

            CreateMap<OrgHierarchy, OrgHierarchyDTO>().ReverseMap();

            CreateMap<CustomerUser, OrgHierarchyDTO>().ReverseMap();
            CreateMap<Engagement, EngagementDTO>().ReverseMap();


            CreateMap<System.Data.DataRow, EngagementHealth>()
                .ForMember(m => m.Customername, s => s.MapFrom(r => r.ItemArray[0].ToString()))
                .ForMember(m => m.Engagementvalue, s => s.MapFrom(s => (int)s.ItemArray[3]))
                .ForMember(m => m.Month, s => s.MapFrom(r => r.ItemArray[1].ToString()))
                .ReverseMap();

            CreateMap<System.Data.DataRow, FinancialHealth>()
                .ForMember(m => m.Customername, s => s.MapFrom(r => r.ItemArray[0].ToString()))
                .ForMember(m => m.Financialvalue, s => s.MapFrom(s => (int)s.ItemArray[2]))
                .ForMember(m => m.Month, s => s.MapFrom(r => r.ItemArray[1].ToString()))
                .ReverseMap();

            CreateMap<System.Data.DataRow, Metrics>()
                .ForMember(m => m.Cardid, s => s.MapFrom(r => (int)r.ItemArray[0]))
                .ForMember(m => m.Userid, s => s.MapFrom(s => (int)s.ItemArray[1]))
                .ForMember(m => m.Metricid, s => s.MapFrom(s => (int)s.ItemArray[2]))
                .ForMember(m => m.Operatorid, s => s.MapFrom(s => (int)s.ItemArray[3]))
                .ForMember(m => m.Metricvalue, s => s.MapFrom(s => (int)s.ItemArray[4]))
                .ReverseMap();

            CreateMap<System.Data.DataRow, NoOfAccounts>()
                .ForMember(m => m.NoofAccounts, s => s.MapFrom(r => (int)r.ItemArray[0]))
                .ReverseMap();

            CreateMap<System.Data.DataRow, CustomerList>()
                .ForMember(m => m.customerid, s => s.MapFrom(r => (int)r.ItemArray[0]))
                .ForMember(m => m.customername, s => s.MapFrom(s => s.ItemArray[1].ToString()))
                .ReverseMap();

            CreateMap<System.Data.DataRow, AccountDetailsDTO>()
                .ForMember(m => m.customerName, s => s.MapFrom(r => r.ItemArray[1].ToString()))
                .ForMember(m => m.service, s => s.MapFrom(s => s.ItemArray[2].ToString()))
                .ForMember(m => m.CustomerID, s => s.MapFrom(s => s.ItemArray[0].ToString()))

                .ReverseMap();

            CreateMap<System.Data.DataRow, CustomerDTO>()
                .ForMember(m => m.CustomerId, s => s.MapFrom(r => r.ItemArray[0].ToString()))
                .ForMember(m => m.CustomerName, s => s.MapFrom(r => r.ItemArray[1].ToString()))
                .ForMember(m => m.CreatedOn, s => s.MapFrom(s => s.ItemArray[2].ToString()))
                .ForMember(m => m.ModifiedBy, s => s.MapFrom(s => s.ItemArray[3].ToString()))
                .ForMember(m => m.ModifiedOn, s => s.MapFrom(s => s.ItemArray[4].ToString()))
                .ReverseMap();

            CreateMap<System.Data.DataRow, Filter>()
                .ForMember(m => m.CustomerId, s => s.MapFrom(r => (int)r.ItemArray[0]))
                .ForMember(m => m.CustomerName, s => s.MapFrom(r => r.ItemArray[1].ToString()))
                .ForMember(m => m.CreatedOn, s => s.MapFrom(s => s.ItemArray[2].ToString()))
                .ForMember(m => m.ModifiedBy, s => s.MapFrom(s => s.ItemArray[3].ToString()))
                .ForMember(m => m.ModifiedOn, s => s.MapFrom(s => s.ItemArray[4].ToString()))
                .ReverseMap();

            CreateMap<DownloadExcelDTO, Users>()
            .ForMember(m => m.IsActive, s => s.Ignore())
            .ForMember(m => m.IsActive, s => s.MapFrom(s => s.IsActive == "Y" ? true : false))
            .ForMember(m => m.UserRoleId, s => s.MapFrom(s => s.Role == "L1" ? 1 : 2))
            .ReverseMap();

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            CreateMap<System.Data.DataRow, UsersTableDTO>()
            .ForMember(m => m.Id, s => s.MapFrom(s => (int)s.ItemArray[0]))
            .ForMember(m => m.InnovaId, s => s.MapFrom(s => (int)s.ItemArray[1]))
            .ForMember(m => m.UserName, s => s.MapFrom(s => textInfo.ToTitleCase(s.ItemArray[2].ToString())))
            .ForMember(m => m.UserEmail, s => s.MapFrom(s => s.ItemArray[3].ToString()))
            .ForMember(m => m.Designation, s => s.MapFrom(s => textInfo.ToTitleCase(s.ItemArray[4].ToString())))
            .ForMember(m => m.Role, s => s.MapFrom(s => textInfo.ToTitleCase(s.ItemArray[5].ToString())))
            .ForMember(m => m.IsActiveUI, s => s.MapFrom(s => (bool)s.ItemArray[6] == true ? "Y" : "N"))
            .ForMember(m => m.ModifiedByUI, s => s.MapFrom(s => textInfo.ToTitleCase(s.ItemArray[7].ToString())))
            .ForMember(m => m.ModifiedDateUI, s => s.MapFrom(s => s.ItemArray[8] == DBNull.Value ? null : string.Format("{0:dd MMMM, yyyy } ", (DateTime)s.ItemArray[8]) + ((DateTime)s.ItemArray[8]).ToLongTimeString()))
            .ReverseMap();

            CreateMap<Users, UsersTableDTO>().ReverseMap();

            CreateMap<System.Data.DataRow, UserRoleDTO>()
                .ForMember(m => m.UserRoleId, s => s.MapFrom(s => s.ItemArray[0]))
                .ForMember(m => m.Name, s => s.MapFrom(s => s.ItemArray[1].ToString()))
                .ReverseMap();

            CreateMap<System.Data.DataRow, UserDTO>()
                .ForMember(m => m.UserId, s => s.MapFrom(r => (int)r.ItemArray[0]))
                .ForMember(m => m.UserName, s => s.MapFrom(r => r.ItemArray[1].ToString()))
                .ForMember(m => m.UserEmail, s => s.MapFrom(r => r.ItemArray[2].ToString()))
                .ForMember(m => m.UserRoleId, s => s.MapFrom(r => (int)r.ItemArray[3]))
                .ForMember(m => m.Designation, s => s.MapFrom(r => r.ItemArray[4].ToString()))
                .ReverseMap();

            CreateMap<System.Data.DataRow, Service.Models.ServiceModels.Enabler>()
                 .ForMember(m => m.Id, s => s.MapFrom(s => (int)s.ItemArray[0]))
                 .ForMember(m => m.CustomerId, s => s.MapFrom(s => (int)s.ItemArray[1]))
                 .ForMember(m => m.EnablerTypeId, s => s.MapFrom(s => (int)s.ItemArray[2]))
                 .ForMember(m => m.Title, s => s.MapFrom(s => s.ItemArray[3].ToString()))
                 .ForMember(m => m.AuthorName, s => s.MapFrom(s => s.ItemArray[4].ToString()))
                 .ForMember(m => m.Link, s => s.MapFrom(s => s.ItemArray[5].ToString()))
                 .ReverseMap();

            CreateMap<System.Data.DataRow, CountOfEnabler>()
                .ForMember(m => m.EnablerTypeId, s => s.MapFrom(r => (int)r.ItemArray[0]))
                .ForMember(m => m.EnablerTitle, s => s.MapFrom(r => r.ItemArray[1].ToString()))
                .ForMember(m => m.Count, s => s.MapFrom(r => (int)r.ItemArray[2]))
                .ReverseMap();
        }
    }
}
