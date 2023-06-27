//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using Com.ACSCorp.AccountPlanning.Service.IService;
//using Com.ACSCorp.AccountPlanning.Service.API.Controllers;
//using FluentAssertions;
//using Microsoft.AspNetCore.Mvc;
//using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
//using AccountPlanningTest.MockData;

//namespace AccountPlanningTest.ContollerTest
//{
//    public class CustomerInfoControllerTest
//    {
//        [Theory]
//        [InlineData(0)]
//        [InlineData(-100)]
//        [InlineData(-150)]
//        public async Task GetCustomerVendors_NotFoundForIdLessThan1(int customerId)
//        {
//            //Arrange
//            var customerInfoService = new Mock<ICustomerInfoService>();


//            var sut = new CustomerInfoController(customerInfoService.Object);
//            //Act

//            var result = await sut.GetCustomerVendors(customerId);

//            //Assert

//            result.GetType().Should().Be(typeof(NotFoundObjectResult));
//            (result as NotFoundObjectResult).StatusCode.Should().Be(404);
//        }

//        [Theory]
//        [InlineData(1)]
//        public async Task GetCustomerVendors_ReturnsEmptyList(int customerId)
//        {
//            //Arrange

//            var customerInfoService = new Mock<ICustomerInfoService>();
//            customerInfoService.Setup(x => x.GetCustomerVendors(customerId)).ReturnsAsync(CustomerInfoMockData.EmptyCustomerVendorServiceDTOList());
//            var sut = new CustomerInfoController(customerInfoService.Object);

//            //Act

//            var result = await sut.GetCustomerVendors(customerId);

//            //Assert

//            result.GetType().Should().Be(typeof(NotFoundObjectResult));
//            (result as NotFoundObjectResult).StatusCode.Should().Be(404);

//        }

//        [Theory]
//        [InlineData(1)]
//        public async Task GetCustomerVendors_OkResponse(int customerId)
//        {
//            //Arrange
//            var customerInfoService = new Mock<ICustomerInfoService>();
//            customerInfoService.Setup(x => x.GetCustomerVendors(customerId)).ReturnsAsync(CustomerInfoMockData.CustomerVendorServiceDTOList());
//            var sut = new CustomerInfoController(customerInfoService.Object);

//            //Act
//            var result = await sut.GetCustomerVendors(customerId);

//            //Assert
//            result.GetType().Should().Be(typeof(OkObjectResult));
//            (result as OkObjectResult).StatusCode.Should().Be(200);

//        }

//        [Theory]
//        [InlineData(1)]
//        public async Task GetCustomerVendors_ErrorString(int customerId)
//        {
//            //Arrange
//            var customerInfoService = new Mock<ICustomerInfoService>();
//            customerInfoService.Setup(x => x.GetCustomerVendors(customerId)).ReturnsAsync(CustomerInfoMockData.ErrorMSG());
//            var sut = new CustomerInfoController(customerInfoService.Object);

//            //Act
//            var result = await sut.GetCustomerVendors(customerId);

//            //Assert
//            //Assert.Equal("True",Convert.ToString(result));
//            result.GetType().Should().Be(typeof(BadRequestObjectResult));
//            (result as BadRequestObjectResult).StatusCode.Should().Be(400);

//        }

//        [Theory]
//        [InlineData(1)]
//        public async Task GetCustomerEngagementHealth_NotFoundStatusForNull(int customerId)
//        {
//            //Arrange
//            var customerInfoService = new Mock<ICustomerInfoService>();
//            customerInfoService.Setup(x => x.GetCustomerEngagementHealth(customerId)).ReturnsAsync(CustomerInfoMockData.GetNull());
//            var sut = new CustomerInfoController(customerInfoService.Object);

//            //Act
//            var result = await sut.GetCustomerEngagementHealth(customerId);

//            //Assert
//            result.GetType().Should().Be(typeof(NotFoundObjectResult));
//            (result as NotFoundObjectResult).StatusCode.Should().Be(404);

//        }

//        [Theory]
//        [InlineData(1)]
//        public async Task GetCustomerEngagementHealth_NotFoundStatusForErrorMSG(int customerId)
//        {
//            //Arrange
//            var customerInfoService = new Mock<ICustomerInfoService>();
//            customerInfoService.Setup(x => x.GetCustomerEngagementHealth(customerId)).ReturnsAsync(CustomerInfoMockData.GetErrorMSG());
//            var sut = new CustomerInfoController(customerInfoService.Object);

//            //Act
//            var result = await sut.GetCustomerEngagementHealth(customerId);

//            //Assert
//            result.GetType().Should().Be(typeof(BadRequestObjectResult));
//            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
//        }

//        [Theory]
//        [InlineData(1)]
//        public async Task GetCustomerEngagementHealth_OkStatus(int customerId)
//        {
//            //Arrange
//            var customerInfoService = new Mock<ICustomerInfoService>();
//            customerInfoService.Setup(x => x.GetCustomerEngagementHealth(customerId)).ReturnsAsync(CustomerInfoMockData.GetCustomerEngagementHealthDTO());
//            var sut = new CustomerInfoController(customerInfoService.Object);

//            //Act
//            var result = await sut.GetCustomerEngagementHealth(customerId);

//            //Assert
//            result.GetType().Should().Be(typeof(OkObjectResult));
//            (result as OkObjectResult).StatusCode.Should().Be(200);

//        }




using AccountPlanningTest.MockData;
using Com.ACSCorp.AccountPlanning.Service.API.Controllers;
using Com.ACSCorp.AccountPlanning.Service.IService;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace AccountPlanningTest.ContollerTest
{
    public class CustomerInfoControllerTest
    {
       

        //[Theory]
        //[InlineData(1)]
        //public async Task GetCustomerInfoController_ShouldReturn200Status(int CustomerId)
        //{
        //    ///Arrange
        //    var CustomerInfoService = new Mock<ICustomerInfoService>();
        //    CustomerInfoService.Setup(x => x.GetCustomerBusinessInformation(CustomerId)).ReturnsAsync(CustomerInfoMockData.GetCustomerBusinessInfo());
        //    // CustomerInfoService.Setup(x => x.GetCustomerBusinessInformation(CustomerId)).ReturnsAsync(CustomerInfoMockData.GetCustomerBusinessInfo());
        //    var sut = new CustomerInfoController(CustomerInfoService.Object);

        //    ///Act
        //    var result = await sut.GetCustomerBusinessInformation(CustomerId);

        //    ///Assert
        //    result.GetType().Should().Be(typeof(OkObjectResult));
        //    //(result as OkObjectResult).Should().Be(200);
        //}

        //[Theory]
        //[InlineData(-1)]
        //public async Task GetCustomerController_ShouldReturn400Status(int CustomerId)
        //{

        //    ///Arrange
        //    var CustomerInfoService = new Mock<ICustomerInfoService>();
        //    CustomerInfoService.Setup(x => x.GetCustomerBusinessInformation(CustomerId)).ReturnsAsync(CustomerInfoMockData.GetCustomerBusinessInfo());
        //    var sut = new CustomerInfoController(CustomerInfoService.Object);

        //    ///Act
        //    var result = await sut.GetCustomerBusinessInformation(CustomerId);

        //    ///Assert
        //    result.GetType().Should().Be(typeof(OkObjectResult));
        //}

    }
}
