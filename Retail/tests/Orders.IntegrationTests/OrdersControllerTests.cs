using System;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using System.IO;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using System.Collections.Generic;

namespace Orders.IntegrationTests
{
    public class OrdersControllerTest : IntegrationTest
    {

        [Theory]
        [InlineData("api/orders/")]
        public async Task GetAll_ShouldBeOKAndCorrectContentType(string url)
        {

            // Arange
            //await AuthenticateAsync();

            // Act
            var response = await TestClient.GetAsync(url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

    }

}


