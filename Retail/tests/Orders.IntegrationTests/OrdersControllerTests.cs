using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Orders.IntegrationTests
{
    public class OrdersControllerTest : IntegrationTest
    {

        [Fact]
        public async Task GetAll_ShouldBeOKAndCorrectContentType()
        {

            // Arange
            //await AuthenticateAsync();

            // Act
            var response = await TestClient.GetAsync("api/orders/");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Theory]
        [InlineData("api/orders/1")]
        [InlineData("api/orders/2")]
        [InlineData("api/orders/3")]
        public async Task Get_ShouldBeOKAndCorrectContentType(string url)
        {

            // Arange
            //await AuthenticateAsync();

            // Act
            var response = await TestClient.GetAsync(url);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Theory]
        [InlineData("api/orders/1")]
        public async Task Put_ShouldBeOKAndCorrectContentType(string url)
        {

            // Arange
            //await AuthenticateAsync();
            var payload = "{\"OrderId\": 1, \"OrderNumber\": 1, \"OrderRegistrationNumber\": 1}";
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            // Act
            var response = await TestClient.PutAsync(url, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Theory]
        [InlineData("api/orders/")]
        public async Task Post_ShouldBeOKWithRespondNewAndCorrectContentType(string url)
        {

            // Arange
            //await AuthenticateAsync();
            var uniqueId = DateTime.Now.ToString("MMddmmssff");
            var payload = "{\"OrderNumber\": " + uniqueId + ", \"OrderRegistrationNumber\": " + uniqueId + "}";
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            // Act
            var response = await TestClient.PostAsync(url, content);
            var contents = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
            contents.Should().Contain("\"orderStatus\":\"New\"");
        }


        [Theory]
        [InlineData("api/orders/", 1, 1)]
        [InlineData("api/orders/", 2, 2)]
        [InlineData("api/orders/", 3, 3)]
        public async Task Post_ShouldBeConflictAndCorrectContentType(string url, long key1, long key2)
        {

            // Arange
            //await AuthenticateAsync();
            var payload = "{\"OrderNumber\": " + key1 + ", \"OrderRegistrationNumber\": " + key2 + "}";
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            // Act
            var response = await TestClient.PostAsync(url, content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
            response.Content.Headers.ContentType.ToString().Should().Be("application/problem+json; charset=utf-8");
        }

    }

}