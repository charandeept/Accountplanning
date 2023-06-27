using AccountPlanningTest.MockData;
using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.API.Controllers;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Mapper;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AccountPlanningTest.ContollerTest
{
    public class OrgHierarchyControllerTest
    {
        private readonly OrgHierarchyController _orgHierarchyController;
        private readonly Mock<IOrgHierarchyService> _mockOrgHierarchyService;
        private readonly Mock<ICustomerUsersService> _mockCustomerUsersService;
        private readonly IMapper _mapper;
        private static readonly object Filterconditions;

        public OrgHierarchyControllerTest()
        {
            _mockCustomerUsersService = new Mock<ICustomerUsersService>();
            _mockOrgHierarchyService = new Mock<IOrgHierarchyService>();
            _orgHierarchyController = new OrgHierarchyController(
                _mockOrgHierarchyService.Object, _mockCustomerUsersService.Object);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
        
        List<CustomerUser> MockCustomerUsers = CustomerUsersMockData.GetCustomerUsers();
        List<OrgHierarchy> MockOrgHierarchy = OrgHierarchyMockData.GetOrgHierarchy();
        List<Users> MockInnovaUsers = InnovaUsersMockData.GetInnovaUsers();
        List<InfluencerKdm> MockInfluencerKdm = InfluencerKdmMockData.GetInfluencerKdm();
        List<OrgHierarchyDTO> MockOrgHierarchyFilter = OrgHierarchyMockData.FilterData();


        [Theory]
        [InlineData(1)]
        public async Task GetById_ReturnsOk_WhenDataFound(int Id)
        {
            //Arrange
            _mockOrgHierarchyService.Setup(x => x.GetById(Id))
                .ReturnsAsync(Result.Ok(_mapper.Map<List<OrgHierarchyDTO>>(MockOrgHierarchy.Where(o=>o.Id==Id))));

            //Act
            var result = await _orgHierarchyController.GetById(Id);

            //Assert
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
            ((result as OkObjectResult).Value as List<OrgHierarchyDTO>).Count.Should().Be(1);
        }


        [Theory]
        [InlineData(-1)]
        public async Task GetById_ReturnsBadRequest_WhenDataNotfound(int Id)
        {
            //Arrange
            _mockOrgHierarchyService.Setup(x => x.GetById(Id))
                .ReturnsAsync(Result.Fail<List<OrgHierarchyDTO>>("Failed to get Details"));

            //Act
            var result = await _orgHierarchyController.GetById(Id);

            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        

        [Theory]
        [InlineData(1)]
        public async Task GetDetails_ReturnsOk_ShouldReturn200Status(int customerId)
        {
            var orgHierarchyByCustomerId = MockOrgHierarchy.Where(o => o.CustomerId == customerId);

            var x = _mapper.Map<List<OrgHierarchyDTO>>(orgHierarchyByCustomerId);
            foreach(var y in x)
            {
                y.InnovaDM_Name = MockInnovaUsers.First(i => i.Id == y.InnovaDmid).UserName;
                y.InfluencerOrKdm_Name = MockInfluencerKdm.First(i => i.Id == y.InfluencerKdmId).Name;
                y.ReportsTO_Name = MockCustomerUsers.First(i => i.Id == y.ReportsToId).Name;
                y.Name = MockCustomerUsers.First(i => i.Id == y.UserId).Name;
            }

            //Arrange
            _mockOrgHierarchyService.Setup(_ => _.GetDetails(customerId)).ReturnsAsync(Result.Ok(x));

            //Act
            var result = await _orgHierarchyController.GetDetails(customerId);
            
            //Assert
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
            ((result as OkObjectResult).Value as List<OrgHierarchyDTO>).Count.Should().Be(1);
        }


        [Theory]
        [InlineData(-1)]
        public async Task GetDetails_ReturnsBadRequest_ShouldReturn400Status(int customerId)
        {
            //Arrange
            _mockOrgHierarchyService.Setup(_ => _.GetDetails(customerId))
                .ReturnsAsync(Result.Fail<List<OrgHierarchyDTO>>("Failed to get details"));

            //Act
            var result = await _orgHierarchyController.GetDetails(customerId);

            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }    



        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
            {
                new object[]{ new OrgHierarchyDTO()
                {
                    Id = 1,
                    Name="a",
                    Designation = "Manager",
                    InfluencerKdmId = 1,
                    EngagementLevelId = 3,
                    InnovaDmid = 1,
                    ReportsToId = 1,
                    LinkedInUrl = "https://www.linkedin.com/company/acs-solutions-corp/",
                    Persona = "Team Player",
                    RoleDescription = "Manages the scope of Project",
                    CustomerId = 1,
                    Gender = "Male"
                }},
                new object[]{ new OrgHierarchyDTO()
                {
                    Name="a",
                    Designation = "Manager",
                    InfluencerKdmId = 1,
                    EngagementLevelId = 3,
                    InnovaDmid = 1,
                    ReportsToId = 1,
                    LinkedInUrl = "https://www.linkedin.com/company/acs-solutions-corp/",
                    Persona = "Team Player",
                    RoleDescription = "Manages the scope of Project",
                    CustomerId = 1,
                    Gender = "Male"
                }}
            };
        }
        

        public int SaveInCustomerUser(OrgHierarchyDTO user)
        {
            var c_record = _mapper.Map<CustomerUser>(user);
            if (user.Id == 0)
            {
                c_record.Id = MockCustomerUsers.Count + 1;
                MockCustomerUsers.Add(c_record);
            }
            else
            {
                var record = MockCustomerUsers.First(c => c.Id == MockOrgHierarchy.First(o => o.Id == user.Id).UserId);
                record = c_record;
                record.Id = (int)MockOrgHierarchy.First(o => o.Id == user.Id).UserId;
                c_record.Id = record.Id;
            }
            return c_record.Id;
        }

        
        public OrgHierarchyDTO SaveInOrgHierarchy(int customerUserId, OrgHierarchyDTO user)
        {
            var o_record = _mapper.Map<OrgHierarchy>(user);
            o_record.UserId = customerUserId;
            if (user.Id == 0)
            {
                o_record.Id = MockOrgHierarchy.Count + 1;
                MockOrgHierarchy.Add(o_record);
            }
            else
            {
                var record = MockOrgHierarchy.First(o => o.Id == user.Id);
                record = o_record;
                record.Id = user.Id;
            }
            var userInRecord = _mapper.Map<OrgHierarchyDTO>(o_record);
            userInRecord.Name = MockCustomerUsers.First(c => c.Id == o_record.UserId).Name;
            return userInRecord;
        }


        [Theory]
        [MemberData(nameof(Data))]
        public async Task SaveUser_ReturnsOk_WhenDataSaved(OrgHierarchyDTO user)
        {
            var customerUserId = SaveInCustomerUser(user);
            var userInRecord = SaveInOrgHierarchy(customerUserId, user);

            //Arrange
            if (user.Id == 0)
            {
                _mockCustomerUsersService.Setup(_ => _.AddUser(user))
                .ReturnsAsync(Result.Ok(customerUserId));
                _mockOrgHierarchyService.Setup(_ => _.AddUser(customerUserId, user))
                .ReturnsAsync(Result.Ok(userInRecord));
            }
            else
            {
                _mockCustomerUsersService.Setup(_ => _.EditUser(user))
                .ReturnsAsync(Result.Ok(customerUserId));
                _mockOrgHierarchyService.Setup(_ => _.EditUser(customerUserId, user))
                .ReturnsAsync(Result.Ok(userInRecord));
            }

            //Act
            var result = await _orgHierarchyController.SaveUser(user);

            //Assert
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Theory]
        [MemberData(nameof(Data))]
        public async Task SaveUser_ReturnsBadRequest_WhenDataNotSavedInOrgHierarchy(OrgHierarchyDTO user)
        {
            var customerUserId = SaveInCustomerUser(user);

            //Arrange
            if (user.Id == 0)
            {
                _mockCustomerUsersService.Setup(_ => _.AddUser(user))
                .ReturnsAsync(Result.Ok(customerUserId));
                _mockOrgHierarchyService.Setup(_ => _.AddUser(customerUserId, user))
                .ReturnsAsync(Result.Fail<OrgHierarchyDTO>("Failed to add user"));
            }
            else
            {
                _mockCustomerUsersService.Setup(_ => _.EditUser(user))
                .ReturnsAsync(Result.Ok(customerUserId));
                _mockOrgHierarchyService.Setup(_ => _.EditUser(customerUserId, user))
                .ReturnsAsync(Result.Fail<OrgHierarchyDTO>("Failed to edit user"));
            }

            //Act
            var result = await _orgHierarchyController.SaveUser(user);

            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }


        [Theory]
        [MemberData(nameof(Data))]
        public async Task SaveUser_ReturnsBadRequest_WhenDataNotSavedInCustomerUser(OrgHierarchyDTO user)
        {
            //Arrange
            if (user.Id == 0)
            {
                _mockCustomerUsersService.Setup(_ => _.AddUser(user))
                .ReturnsAsync(Result.Fail<int>("Failed to add user"));
                _mockOrgHierarchyService.Setup(_ => _.AddUser(0, user))
                .ReturnsAsync(Result.Fail<OrgHierarchyDTO>("Failed to add user"));
            }
            else
            {
                _mockCustomerUsersService.Setup(_ => _.EditUser(user))
                .ReturnsAsync(Result.Fail<int>("Failed to edit user"));
                _mockOrgHierarchyService.Setup(_ => _.EditUser(0, user))
                .ReturnsAsync(Result.Fail<OrgHierarchyDTO>("Failed to edit user"));
            }

            //Act
            var result = await _orgHierarchyController.SaveUser(user);

            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        public static IEnumerable<object[]> FilterData()
        {
            return new List<object[]>
            {
                new object[]{ new OrgHierarchyFilterGridDTO()
                { 
                Filterconditions=new List<filterlist>()
                    {
                        new filterlist(){ ColumnName="UserName",Operator="Starts with", Value="s"}
                    },
                   CustomerId=1,
                   SearchText="R",
                   OrderColumn="Name",
                   OrderType="Desc"                 
                }}
            };
        }

     
        [Theory]
        [MemberData(nameof(FilterData))]
        public async Task FilterAndSort__ReturnsOk_WhenDataFoundInOrgHierarchy(OrgHierarchyFilterGridDTO data)
        { 
            _mockOrgHierarchyService.Setup(x => x.EditHierarchy_FilterAndSort(data))
               .ReturnsAsync(Result.Ok(OrgHierarchyMockData.FilterData()));

            //Act
            var result = await _orgHierarchyController.EditHierarchy_FilterAndSort(data);

            //Assert
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
            
        }

        [Theory]
        [MemberData(nameof(FilterData))]
        public async Task FilterAndSort__ReturnsBadRequest_WhenDataNotFoundInOrgHierarchy(OrgHierarchyFilterGridDTO data)
        {
            //Arrange
            _mockOrgHierarchyService.Setup(x => x.EditHierarchy_FilterAndSort(data))
                .ReturnsAsync(Result.Fail<List<OrgHierarchyDTO>>("Failed to apply filter, sort and search."));

            //Act
            var result = await _orgHierarchyController.EditHierarchy_FilterAndSort(data);

            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
    }
}