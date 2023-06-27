namespace AccountPlanningTest.ContollerTest
{
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

    public class DesignationControllerTest
    {
        private readonly DesignationController _designationController;
        private readonly Mock<IDesignationService> _mockdesignationService;
        public DesignationControllerTest()
        {
            _mockdesignationService = new Mock<IDesignationService>();
            _designationController = new DesignationController(_mockdesignationService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WhenDataFound()
        {
            //Arrange
            _mockdesignationService.Setup(x => x.GetAll()).ReturnsAsync(Result.Ok(DesignationMockData.GetSample()));

            //Act
            var result = await _designationController.DesignationList();

            //Assert
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAll_ReturnsBadRequest_WhenDataNotfound()
        {
            //Arrange
            _mockdesignationService.Setup(x => x.GetAll()).ReturnsAsync(Result.Fail<List<DesignationDTO>>("Failed to get Designation Details"));

            //Act
            var result = await _designationController.DesignationList();

            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

    }
}
