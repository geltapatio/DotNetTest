using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Dotnet.WebApi.Test
{
    public class BaseTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public BaseTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        public HttpClient GetHttpClient()
        {
           return _factory.CreateClient();
        }
    }
}
