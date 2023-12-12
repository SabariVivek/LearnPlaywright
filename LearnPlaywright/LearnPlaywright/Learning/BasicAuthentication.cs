using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class BasicAuthentication
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

            // URL Launching...
            var context = await browser.NewContextAsync(new()
            {
                HttpCredentials = new HttpCredentials
                {
                    Username = "user",
                    Password = "pass"
                },
            });

            var page = await context.NewPageAsync();
            await page.GotoAsync("https://authenticationtest.com/HTTPAuth/");
        }
    }
}
