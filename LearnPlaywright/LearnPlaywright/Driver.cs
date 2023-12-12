using Microsoft.Playwright;

namespace LearnPlaywright
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver() => _page = InitializePlaywright();

        public IPage Page => _page.GetAwaiter().GetResult();

        private async Task<IPage> InitializePlaywright()
        {
            // Playwright Instance Creation...
            using var playwright = await Playwright.CreateAsync();

            // Browser Setup...
            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = false
            };

            _browser = await playwright.Chromium.LaunchAsync(launchOptions);

            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });

            // Page Setup...
            return await _browser.NewPageAsync();
        }

        public void Dispose() => _browser?.CloseAsync();
    }
}
