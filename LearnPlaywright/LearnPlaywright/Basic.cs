using Microsoft.Playwright;

namespace LearnPlaywright
{
    public class Tests
    {
        public IPage page;

        [Test]
        public async Task BasicTest()
        {
            // Playwright Instance Creation...
            using var playwright = await Playwright.CreateAsync();

            // Browser Setup...
            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = false
            };

            var browser = await playwright.Chromium.LaunchAsync(launchOptions);

            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport
            });

            // Page Setup...
            page = await browser.NewPageAsync();

            // URL Launching...
            await page.GotoAsync("http://eaapp.somee.com/");

            // Other operations...
            await page.Locator("id=loginLink").ClickAsync();
            await page.Locator("id=UserName").FillAsync("admin");
            await page.Locator("id=Password").FillAsync("password");
            await page.Locator("xpath=//input[@value='Log in']").ClickAsync();

            // Page Verfication after logged in...
            await Assertions.Expect(page.GetByText("Log off", new() { Exact = true })).ToBeVisibleAsync();
        }
    }
}