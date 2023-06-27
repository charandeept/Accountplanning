namespace AccountPlanningTest.ContollerTest
{
    using AccountPlanningTest.MockData;
    using Com.ACSCorp.AccountPlanning.Service.API.Controllers;
    using Com.ACSCorp.AccountPlanning.Service.IService;
    using Com.ACSCorp.AccountPlanning.Service.Models;
    using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class DashboardControllerTest
    {
        private readonly DashboardController _dashboardController;
        private readonly Mock<IDashboardService> _mockDashboardService;

        public DashboardControllerTest()
        {
            _mockDashboardService = new Mock<IDashboardService>();
            _dashboardController = new DashboardController(_mockDashboardService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WhenDataFound()
        {
            _mockDashboardService.Setup(x => x.DashboardData())

                .ReturnsAsync(Result.Ok(DashboardMockData.DashboardData()));

            var result = await _dashboardController.Get();

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task GetAll_ReturnsBadRequest_WhenDataNotfound()
        {
            _mockDashboardService.Setup(x => x.DashboardData())
                .ReturnsAsync(Result.Fail<DashboardDTO>("Failed to get Details"));

            var result = await _dashboardController.Get();

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        [Theory]
        [InlineData("acs")]
        public async Task CustomerSearch_ReturnsOk_WhenDataFound(string name)
        {

            _mockDashboardService.Setup(x => x.SearchCustomer(name))

                .ReturnsAsync(Result.Ok(DashboardMockData.SearchCustomer()));

            var result = await _dashboardController.GetCustomer(name);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);

        }
        [Theory]
        [InlineData("abcd")]
        public async Task CustomerSearch_ReturnsBadRequest_WhenDataNotfound(string name)
        {
            _mockDashboardService.Setup(x => x.SearchCustomer(name))
                .ReturnsAsync(Result.Fail<SearchDTO>("Failed to get Searched customer list"));

            var result = await _dashboardController.GetCustomer(name);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }


        [Theory]
        [InlineData(1)]
        public async Task DashboardGetMetrics_ShouldReturn200Status_WhenDataFound(int Id)
        {

            _mockDashboardService.Setup(x => x.GetDetails(Id))

                .ReturnsAsync(Result.Ok(DashboardMockData.NoOfAccounts()));

            var result = await _dashboardController.GetByMetric(Id);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Theory]
        [InlineData(-1)]
        public async Task DashboardGetMetrics_ReturnsBadRequest_WhenDataNotfound(int Id)
        {
            _mockDashboardService.Setup(x => x.GetDetails(Id))
                .ReturnsAsync(Result.Fail<List<AccountDetailsDTO>>("Failed to get Details"));

            var result = await _dashboardController.GetByMetric(Id);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        public static IEnumerable<object[]> GetCustomerListData()
        {
            return new List<object[]>
            {
                new object[]{ new Customer()
                {
                    userId=103543,
                    pageNumber=2,
                    rowsOfPage=5,
                    sortingColumn="name",
                    sortType="AESC"
                } }
            };
        }

        [Theory]
        [MemberData(nameof(GetCustomerListData))]
        public async Task GetCustomerList_ShouldReturn200Status_WhenDataFound(Customer customer)
        {
            _mockDashboardService.Setup(x => x.GetCustomerList(customer))

                .ReturnsAsync(Result.Ok(DashboardMockData.GetCustomerList()));

            var result = await _dashboardController.GetCustomerList(customer);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Theory]
        [MemberData(nameof(GetCustomerListData))]
        public async Task GetCustomerList_ShouldReturn400Status_WhenDataNotFound(Customer customerParameters)
        {
            _mockDashboardService.Setup(x => x.GetCustomerList(customerParameters))

               .ReturnsAsync(Result.Fail<List<CustomerDTO>>("Failed to get customer list"));

            var result = await _dashboardController.GetCustomerList(customerParameters);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }

        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
            {
                new object[]
                {
                   new MetricsDTO()
                   {
                       Id=0,
                       UserID=2,
                       MetricsID=1,
                       OperatorID=1,
                       Value=3
                   }
                }
            };
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task SaveMetric_ShouldReturn201Status_WhenDataSaved(MetricsDTO metrics)
        {
            var MetricStatus = DashboardMockData.CreateMetrics();
            _mockDashboardService.Setup(x => x.CreateMetrics(metrics))

            .ReturnsAsync(Result.Ok(MetricStatus));

            var result = await _dashboardController.Post(metrics);

            result.Should().BeAssignableTo<CreatedAtActionResult>();
            (result as CreatedAtActionResult).StatusCode.Should().Be(201);
        }
        [Theory]
        [MemberData(nameof(Data))]
        public async Task SaveMetric_ReturnsBadRequest_WhenDataNotSaved(MetricsDTO metrics)
        {
            _mockDashboardService.Setup(x => x.CreateMetrics(metrics))
               .ReturnsAsync(Result.Fail<bool>("Failed to save metrics details"));

            var result = await _dashboardController.Post(metrics);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);

        }

        [Theory]
        [InlineData(1)]
        public async Task RemoveMetric_ShouldReturn200Status_WhenMetricRemoved(int cardid)
        {
            var MetricStatus = DashboardMockData.RemoveMetrics();

            _mockDashboardService.Setup(x => x.RemoveMetrics(cardid))
                .ReturnsAsync(Result.Ok(MetricStatus));

            var result = await _dashboardController.Delete(cardid);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Theory]
        [InlineData(-1)]
        public async Task RemoveMetric_ShouldReturn400Status_WhenMetricNotRemoved(int cardid)
        {
            _mockDashboardService.Setup(x => x.RemoveMetrics(cardid))
               .ReturnsAsync(Result.Fail<bool>("Failed to save metric details"));

            var result = await _dashboardController.Delete(cardid);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);

        }

        [Fact]
        public async Task CustomerFilter_ShouldReturn200Status_WhenDataFound()
        {
            List<FilterGridDTO> filters = new List<FilterGridDTO>();
            FilterGridDTO filterGrid = new FilterGridDTO()
            {
                ColumnName = "name",
                Operator = "Contains",
                Value = "a",
                UserId = 2
            };
            filters.Add(filterGrid);
            _mockDashboardService.Setup(x => x.CustomerFilter(filters))
                .ReturnsAsync(Result.Ok(DashboardMockData.CustomerFilter()));

            var result = await _dashboardController.CustomerFilter(filters);

            result.Should().BeAssignableTo<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task CustomerFilter_ShouldReturn400Status_WhenDataNotFound()
        {
            List<FilterGridDTO> filters = new List<FilterGridDTO>();
            FilterGridDTO filterGrid = new FilterGridDTO()
            {
                ColumnName = "name",
                Operator = "Contains",
                Value = "a",
                UserId = 2
            };
            filters.Add(filterGrid);
            _mockDashboardService.Setup(x => x.CustomerFilter(filters))
               .ReturnsAsync(Result.Fail<FilterDTO>("Failed to get filtered data"));

            var result = await _dashboardController.CustomerFilter(filters);

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);

        }
    }
}
