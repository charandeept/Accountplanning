using AccountPlanningTest.MockData;
using Com.ACSCorp.AccountPlanning.Service.API.Controllers;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels;
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
    public class EnablersControllerTest
    {
        private readonly EnablersController _enablersController;
        private readonly Mock<IEnablerService> _mockEnablerService;
        public EnablersControllerTest()
        {
            _mockEnablerService = new Mock<IEnablerService>();
            _enablersController = new EnablersController(_mockEnablerService.Object);
        }
        [Fact]
        public async Task GetAll_ReturnsOk_WhenDataFound()
        {
            _mockEnablerService.Setup(x => x.GetEnablers())

                .ReturnsAsync(Result.Ok(EnablersMockData.EnablerData()));

            var result = await _enablersController.GetEnablers();

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task GetAll_ReturnsBadRequest_WhenDataNotfound()
        {
            _mockEnablerService.Setup(x => x.GetEnablers())
                .ReturnsAsync(Result.Fail<EnablerDTO>("Failed to get Details"));

            var result = await _enablersController.GetEnablers();

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task CreateEnablers_ShouldReturn200Status_WhenDataSaved()
        {
            int id = 1;
            EnablersBM enabler = new EnablersBM()
            {
                CustomerId = 1,
                EnablerTypeId = 2,
                Title = "Java",
                AuthorName = "Akish",
                Link = "www.akish.com"
            };
            _mockEnablerService.Setup(x => x.CreateEnablers(id, enabler))
               .ReturnsAsync(Result.Ok(EnablersMockData.addEnablers()));

            var result = await _enablersController.CreateEnablers(id, enabler);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task CreateEnablers_ShouldReturn400Status_WhenDataNotSaved()
        {
            int id = 1;
            EnablersBM enabler = new EnablersBM()
            {
                CustomerId = 1,
                EnablerTypeId = 2,
                Title = "Java",
                AuthorName = "Akish",
                Link = "www.akish.com"
            };
            _mockEnablerService.Setup(x => x.CreateEnablers(id, enabler))
               .ReturnsAsync(Result.Fail<EnablersBM>("Failed to save enabler data"));

            var result = await _enablersController.CreateEnablers(id, enabler);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }


        [Fact]
        public async Task CreateEnabler_ShouldReturn200Status_WhenDataSaved()
        {
            int id = 1;
            EnablerTypeBM enabler = new EnablerTypeBM() { Title = "string" };

            _mockEnablerService.Setup(x => x.SaveEnablerType(id, enabler))
               .ReturnsAsync(Result.Ok(EnablersMockData.CreateEnabler()));

            var result = await _enablersController.SaveEnablerType(id, enabler);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task CreateEnabler_ShouldReturn400Status_WhenDataNotSaved()
        {
            int id = 1;
            EnablerTypeBM enabler = new EnablerTypeBM() { Title = "string" };

            _mockEnablerService.Setup(x => x.SaveEnablerType(id, enabler))
            .ReturnsAsync(Result.Fail<EnablerTypeBM>("Failed to save enabler data"));

            var result = await _enablersController.SaveEnablerType(id, enabler);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task RemoveEnabler_ShouldReturn200Status_WhenDataRemoved()
        {
            int id = 1;
            _mockEnablerService.Setup(x => x.RemoveEnablerType(id))
            .ReturnsAsync(Result.Ok(EnablersMockData.RemoveEnabler()));

            var result = await _enablersController.RemoveEnablerType(id);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task RemoveEnabler_ShouldReturn400Status_WhenDataNotRemoved()
        {
            int id = 1;
            _mockEnablerService.Setup(x => x.RemoveEnablerType(id))
            .ReturnsAsync(Result.Fail<bool>("Failed to remove enabler data"));

            var result = await _enablersController.RemoveEnablerType(id);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task RemoveEnablerCard_ShouldReturn200Status_WhenDataRemoved()
        {
            int id = 1;
            _mockEnablerService.Setup(x => x.RemoveEnabler(id))
            .ReturnsAsync(Result.Ok(EnablersMockData.RemoveEnablerCard()));

            var result = await _enablersController.RemoveEnabler(id);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task RemoveEnablerCard_ShouldReturn400Status_WhenDataNotRemoved()
        {
            int id = 1;
            _mockEnablerService.Setup(x => x.RemoveEnabler(id))
            .ReturnsAsync(Result.Fail<bool>("Failed to remove enabler card details"));

            var result = await _enablersController.RemoveEnabler(id);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
    }
}
