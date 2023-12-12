using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class ReusingLoginAction
    {
        [Test]
        public async Task ReusingLoginActionTest()
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
            await page.GotoAsync("https://practicetestautomation.com/practice-test-login/");

            // Login Functionality...
            await page.Locator("#username").FillAsync("student");
            await page.Locator("#password").FillAsync("Password123");
            await page.Locator("#submit").ClickAsync();

            // Save storage state into the file...
            Screenshot screenshot = new Screenshot();
            await context.StorageStateAsync(new()
            {
                Path = screenshot.GetProjectDirectory() + "\\Utils\\LoginState.json"
            });

            await page.WaitForTimeoutAsync(3000);
        }

        [Test]
        public async Task ReusingSameLoginState()
        {
            // Browser & Page Configuration...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            // Create a new context with the saved storage state...
            Screenshot screenshot = new Screenshot();
            var context = await browser.NewContextAsync(new()
            {
                StorageStatePath = screenshot.GetProjectDirectory() + "\\Utils\\LoginState.json"
            });
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://practicetestautomation.com/practice-test-login/");

            await page.WaitForTimeoutAsync(3000);
        }
    }
}
