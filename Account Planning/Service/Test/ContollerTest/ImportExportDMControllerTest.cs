using AccountPlanningTest.MockData;
using Com.ACSCorp.AccountPlanning.Service.API.Controllers;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;



namespace AccountPlanningTest.ContollerTest
{
    public class ImportExportDMControllerTest
    {
        private readonly ImportExportDMController _importExportDMController;
        private readonly Mock<IImportExportDMService> _importExportDMService;
        public ImportExportDMControllerTest()
        {
            _importExportDMService = new Mock<IImportExportDMService>();
            _importExportDMController = new ImportExportDMController(_importExportDMService.Object);
        }
        [Fact]
        public async Task DMTemplate_ShouldReturnOk_WhenDataFound()
        {
            //Arrange
            _importExportDMService.Setup(x => x.GetExcelTemplate())
                .ReturnsAsync(ImportExportDMMockData.DMTemplateData_NotBeNull());

            //Act
            var result = await _importExportDMController.DownloadTemplate();

            //Assert
            result.Should().BeAssignableTo<Object>();
            (result as Object).Should().NotBeNull();

        }
        [Fact]
        public async Task DMTemplate_ShouldReturnOk_WhenDataNotFound()
        {
            _importExportDMService.Setup(x => x.GetExcelTemplate())
            .ReturnsAsync(ImportExportDMMockData.DMTemplate_NullData());

            var result = await _importExportDMController.DownloadTemplate();

            result.Should().BeAssignableTo<Object>();
            (result as Object).Should().NotBeNull();
        }


        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
            {
                new object[]{ new ImportUsers_FilterAndSort()
                {
                    Filter=new List<FilterParametersInImportUsers>()
                    {
                        new FilterParametersInImportUsers(){ ColumnName="UserName",Operator="Starts with", Value="s"}
                    },
                    OrderColumn="UserName",
                    OrderType="Asc",
                    SearchText="sameera"
                }}
            };
        }


        [Theory]
        [MemberData(nameof(Data))]
        public async Task FilterUsers_ShouldReturnOk_WhenDataFound(ImportUsers_FilterAndSort importUsers_FilterAndSort)
        {
            _importExportDMService.Setup(x => x.FilterUsers(importUsers_FilterAndSort))
            .ReturnsAsync(Result.Ok(ImportExportDMMockData.GetUsers()));

            var result = await _importExportDMController.FilterUsers(importUsers_FilterAndSort);
            
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Theory]
        [MemberData(nameof(Data))]
        public async Task FilterUsers_ShouldReturnBadRequest_WhenDataNotFound(ImportUsers_FilterAndSort importUsers_FilterAndSort)
        {
            _importExportDMService.Setup(x => x.FilterUsers(importUsers_FilterAndSort))
            .ReturnsAsync(Result.Fail<List<UsersTableDTO>>("Failed to apply filter, sort and search."));
            
            var result = await _importExportDMController.FilterUsers(importUsers_FilterAndSort);
            
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }


        [Fact]
        public async Task displayUsersTable_ShouldReturnOk_WhenDataFound()
        {
            _importExportDMService.Setup(x => x.displayUsersTable())
            .ReturnsAsync(Result.Ok(ImportExportDMMockData.GetUsers())); 
            
            var result = await _importExportDMController.displayUsersTable(); 
            
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task displayUsersTable_ShouldReturnBadRequest_WhenDataNotFound()
        {
            _importExportDMService.Setup(x => x.displayUsersTable())
            .ReturnsAsync(Result.Fail<List<UsersTableDTO>>("Failed to display users.")); 
            
            var result = await _importExportDMController.displayUsersTable(); 
            
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
    }
}