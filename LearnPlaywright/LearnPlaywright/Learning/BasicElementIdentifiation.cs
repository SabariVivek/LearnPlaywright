using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class BasicElementIdentifiation
    {
        [Test]
        public async Task ElementIdentification()
        {
            // Browser & Page Configuration...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();

            // URL Launching...
            await page.GotoAsync("https://www.leafground.com/dashboard.xhtml");

            // Right Side Element Count Identification...
            var ThreeDots = page.Locator("#right-sidebar-button");
            await ThreeDots.ClickAsync();
            await Assertions.Expect(page.Locator("xpath=//ul[@role='tablist']/li")).ToHaveCountAsync(3);
            await ThreeDots.ClickAsync();

            // Seleting all the checkboxes in a table...
            int CheckBoxes = await page.Locator("//div[contains(@class,'weekly-tasks')]//ul/li/div[not(text())]").CountAsync();
            for (int i = 1; i <= CheckBoxes; i++)
            {
                await page.Locator("(//div[contains(@class,'weekly-tasks')]//ul/li/div[not(text())])[" + i + "]").ClickAsync();
            }

            // Handling Resolution Center...
            await page.Locator("#email").FillAsync("sabari@gmail.com");
            await page.Locator("#message").FillAsync("Hi, This is Sabari Vivekananda...");
            await page.Locator("//span[text()='Send']").ClickAsync();

            await page.WaitForTimeoutAsync(3000);
        }
    }
}
