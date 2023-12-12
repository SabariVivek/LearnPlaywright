using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class AlertHandling
    {
        [Test]
        public async Task AlertHandlingTest()
        {
            // Browser & Page Configuration...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            // URL Launching...
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.leafground.com/alert.xhtml");

            // Basic Alert...
            await Console.Out.WriteLineAsync("Basic Alert");
            await page.Locator("//*[text()=' Alert (Simple Dialog)']/following-sibling::button/span[text()='Show']").ClickAsync();
            page.Dialog += (_, dialog) => dialog.AcceptAsync();

            // Confirm Alert...
            await Console.Out.WriteLineAsync("Confirm Alert");
            await page.Locator("//*[text()=' Alert (Confirm Dialog)']/following-sibling::button/span[text()='Show']").ClickAsync();
            page.Dialog += (_, dialog) => dialog.DismissAsync();

            // Prompt Alert...
            await Console.Out.WriteLineAsync("Prompt Alert");
            await page.Locator("//*[text()=' Alert (Prompt Dialog)']/following-sibling::button/span[text()='Show']").ClickAsync();
            page.Dialog += (_, dialog) => dialog.AcceptAsync("Sabari Vivek");
        }
    }
}
