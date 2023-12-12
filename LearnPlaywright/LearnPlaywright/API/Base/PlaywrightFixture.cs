using LearnPlaywright.API.Config;
using Microsoft.Playwright;

namespace LearnPlaywright.API.Base
{
    public class PlaywrightFixture
    {
        public static IPlaywright? playwright { get; set; }
        public static IAPIRequestContext? requestContext { get; set; }
        public static IAPIResponse? response { get; set; }

        public static async Task<IAPIRequestContext> CreateAsync()
        {
            // Config Loader...
            var config = ConfigReader.ReadConfig();

            // Initialization of Playwright object & Request Context...
            playwright = await Playwright.CreateAsync();
            requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = config.BaseUrl,
                IgnoreHTTPSErrors = true,
            });
            return requestContext;
        }
    }
}