using Microsoft.Extensions.Configuration;
using RadarrApiWrapper.IntegrationTests.Common.AppSettings;
using RestSharp;
using Xunit.Abstractions;

namespace RadarrApiWrapper.IntegrationTests.Common.Helpers
{
    public class CommonHelper
    {
        public ITestOutputHelper OutputHelper { get; set; }
        public Settings Settings { get; }
        public RestClient RestClient { get; }

        public CommonHelper()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Settings = new Settings();
            configuration.Bind(Settings);
            RestClient = new RestClient(Settings.RadarrApiBaseUrl);
            RestClient.AddDefaultHeader("X-Api-Key", Settings.RadarrApiKey);
        }
    }
}
