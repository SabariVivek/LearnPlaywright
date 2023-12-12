using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class IFrameHandling
    {
        [Test]
        public async Task FrameHandlingTest()
        {
            // Browser & Page Configuration...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();

            // URL Launching - 1...
            await page.GotoAsync("https://letcode.in/frame");

            await page.FrameLocator("iframe[name='firstFr']").GetByPlaceholder("Enter name").FillAsync("Sabari");
            await page.FrameLocator("iframe[name='firstFr']").GetByPlaceholder("Enter email").FillAsync("Vivek");
            await page.FrameLocator("iframe[name='firstFr']").
                FrameLocator("//iframe[@src='innerFrame']").GetByPlaceholder("Enter email").FillAsync("sabari@gmail.com");
            await page.WaitForTimeoutAsync(3000);

            // URL Launching - 2...
            await page.GotoAsync("https://www.leafground.com/frame.xhtml");

            // Frame 1...
            var Frame1Locator = page.FrameLocator("//iframe[@src='default.xhtml']").GetByText("Click");
            await Frame1Locator.ClickAsync();
            await Assertions.Expect(Frame1Locator).ToHaveTextAsync("Hurray! You Clicked Me.");

            // Frame 2...
            var Frame2Locator = page.FrameLocator("//iframe[@src='page.xhtml']").
                FrameLocator("#frame2").GetByText("Click");
            await Frame2Locator.ClickAsync();
            await Assertions.Expect(Frame2Locator).ToHaveTextAsync("Hurray! You Clicked Me.");
            await page.WaitForTimeoutAsync(3000);
        }
    }
}
