using Dotnet.WebApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace Dotnet.WebApi.Test
{
    public class DotNetWebApitest: BaseTest
    {
        public DotNetWebApitest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Test1()
        {
            var response = await GetHttpClient().GetAsync("/WeatherForecast").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.NotEmpty(contentString);

            var contentModels = JsonSerializer.Deserialize<IReadOnlyList<WeatherForecast>>(contentString);
            Assert.NotNull(contentModels);
            Assert.Equal(5, contentModels!.Count);
            Assert.All(contentModels, model =>
            {
                Assert.True(model.TemperatureC >= -20);
                Assert.True(model.TemperatureC < 55);
            });
        }
    }
}