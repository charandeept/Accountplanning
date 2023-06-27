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
    public class InfluencerControllerTest
    {
        private readonly InfluencerController _influencerController;
        private readonly Mock<IInfluencerService> _influencerService;
        private IMapper _mapper;

        public InfluencerControllerTest()
        {
            _influencerService = new Mock<IInfluencerService>();
            _influencerController = new InfluencerController(_influencerService.Object);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
        

        [Fact]
        public async Task InfluencerList_ShouldReturn200StatusInfluencer()
        {
            //Arrange
            
            _influencerService.Setup(x => x.GetAll())
                .ReturnsAsync(Result.Ok(_mapper.Map<List<InfluencerDTO>>(InfluencerMockData.GetInfluencerData())));
           

            //Act
            var result = await _influencerController.InfluencerList();

            //Assert
            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
            ((result as OkObjectResult).Value as List<InfluencerDTO>).Count.Should().Be(2);
        }

        

        [Fact]
        public async Task InfluencerList_ShouldReturn400Status()
        {
            //Arrange
            
            _influencerService.Setup(x => x.GetAll()).ReturnsAsync(Result.Fail<List<InfluencerDTO>>("Failed to get details"));
           

            //Act
            
            var result = await _influencerController.InfluencerList();

            //Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
    }
}
