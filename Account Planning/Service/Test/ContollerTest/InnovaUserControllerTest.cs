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

    public class InnovaUserControllerTest
    {
        private readonly InnovaUserController _innovauserController;
        private readonly Mock<IInnovaUserService> _mockinnovauserService;
        public InnovaUserControllerTest()
        {
            _mockinnovauserService = new Mock<IInnovaUserService>();
            _innovauserController = new InnovaUserController(_mockinnovauserService.Object);
        }
        [Fact]
        public async Task GetAll_ReturnsOk_WhenDataFound()
        {
            //Arrange
            _mockinnovauserService.Setup(x => x.GetAll()).ReturnsAsync(Result.Ok(InnovaUserMockData.GetSample()));

            //Act
            var result = await _innovauserController.InnovaUserList();

            //Assert
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetAll_ReturnsBadRequest_WhenDataNotfound()
        {
            //Arrange
            _mockinnovauserService.Setup(x => x.GetAll()).ReturnsAsync(Result.Fail<List<InnovaUserDTO>>("Failed to get InnovaUser Details"));

            //Act
            var result = await _innovauserController.InnovaUserList();

            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

    }
}
