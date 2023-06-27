using AccountPlanningTest.MockData;
using AutoMapper;
using Com.ACSCorp.AccountPlanning.Service.API.Controllers;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Mapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AccountPlanningTest.ContollerTest
{
    public class EngagementControllerTest
    {
        private readonly EngagementController _engagementController;
        private readonly Mock<IEngagementService> _engagementService;
        private IMapper _mapper;

        public EngagementControllerTest()
        {
            _engagementService = new Mock<IEngagementService>();
            _engagementController = new EngagementController(_engagementService.Object);
            var mappingConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new ApplicationMapper());
             });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
        [Fact]
        public async Task EngagementLevel_shouldReturn200Status()
        {
            //Arrange
            _engagementService.Setup(x => x.GetEngagementLevel())
                .ReturnsAsync(Result.Ok(_mapper.Map<List<EngagementDTO>>(EngagementMockData.GetEngagementData())));
            //Act
            var result = await _engagementController.EngagementLevelDD();

            //Assert
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
            ((result as OkObjectResult).Value as List<EngagementDTO>).Count.Should().Be(3);
        }
        [Fact]
        public async Task EngagementLevel_ShouldReturn400Status()
        {
            //Arrange
            _engagementService.Setup(x => x.GetEngagementLevel())
                .ReturnsAsync(Result.Fail<List<EngagementDTO>>("Failed to get Engagement Levels"));
            //Act
            var result = await _engagementController.EngagementLevelDD();
            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
    }
}