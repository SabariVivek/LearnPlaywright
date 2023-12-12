using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class WindowHandling
    {
        [Test]
        public async Task WindowHandlingTest()
        {
            // Browser & Page Configuration...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            // URL Launching...
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://www.leafground.com/window.xhtml");

            // Get page after a specific action (e.g. clicking a link)
            var newPage = await context.RunAndWaitForPageAsync(async () =>
            {
                await page.Locator("//span[text()='Open']").ClickAsync();
            });
            await newPage.WaitForLoadStateAsync();
            Console.WriteLine(await newPage.TitleAsync());
            await newPage.CloseAsync();

            // Getting back to Parent Window...
            await page.GetByPlaceholder("Search...").FillAsync("Sabari Vivek");
            await page.WaitForTimeoutAsync(3000);
        }

        [Test]
        public async Task MultiPagesHandling()
        {
            // Browser & Page Configuration...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            // URL Launching...
            var context = await browser.NewContextAsync();

            // Create two pages
            var pageOne = await context.NewPageAsync();
            await pageOne.GotoAsync("https://omayo.blogspot.com");

            var pageTwo = await context.NewPageAsync();
            await pageTwo.GotoAsync("http://google.com");

            // Get pages of a browser context
            var allPages = context.Pages;
            foreach (var page in allPages)
            {
                await Console.Out.WriteLineAsync(page.Url);
            }
        }
    }
}