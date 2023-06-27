using AccountPlanningTest.MockData;
using Com.ACSCorp.AccountPlanning.Service.API.Controllers;
using Com.ACSCorp.AccountPlanning.Service.IService;
using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
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
    public class CustomerUsersControllerTest
    {
        private readonly CustomerUsersController _customerUsersController;
        private readonly Mock<ICustomerUsersService> _mockCustomerUsersService;


        public CustomerUsersControllerTest()
        {
            _mockCustomerUsersService = new Mock<ICustomerUsersService>();
            _customerUsersController = new CustomerUsersController(_mockCustomerUsersService.Object);
        }


        [Theory]
        [InlineData(1)]
        public async Task GetCustomerUsersByCustomerId_ReturnsOk_WhenDataFound(int customerId)
        {
            _mockCustomerUsersService.Setup(_ => _.GetUsersByCustomerId(customerId))
                .ReturnsAsync(Result.Ok(CustomerUsersMockData.GetCustomerUsers()
                .Where(c => c.CustomerId == customerId)
                .Select(c => new CustomerUserDTO { Id = c.Id, Name = c.Name }).ToList()));

            var result = await _customerUsersController.GetUsersByCustomerId(customerId);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
            ((result as OkObjectResult).Value as List<CustomerUserDTO>).Count.Should().Be(1);
        }


        [Theory]
        [InlineData(-1)]
        public async Task GetCustomerUsersByCustomerId_ReturnsBadRequest_WhenDataNotFound(int customerId)
        {
            _mockCustomerUsersService.Setup(_ => _.GetUsersByCustomerId(customerId))
                .ReturnsAsync(Result.Fail<List<CustomerUserDTO>>("Failed to get users"));

            var result = await _customerUsersController.GetUsersByCustomerId(customerId);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }
    }
}