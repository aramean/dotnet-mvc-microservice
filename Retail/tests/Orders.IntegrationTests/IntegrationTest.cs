using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Orders.Data;

namespace Orders.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var AppFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseSetting("https_port", "443");
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(OrderContext));
                        services.AddDbContext<OrderContext>(options => { options.UseInMemoryDatabase("TestDB"); });
                    });

                });

            TestClient = AppFactory.CreateClient();
        }
        /*
        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            throw new System.NotImplementedException();

            //var response = await TestClient.PostAsJsonAsync("/api/");
        }*/
    }
}
