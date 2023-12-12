using Microsoft.Playwright;
using System.Reflection;

namespace LearnPlaywright.Learning
{
    internal class Screenshot
    {
        [Test]
        public async Task ScreenshotTest()
        {
            // Browser & Page Configuration...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();

            // URL Launching...
            await page.GotoAsync("https://letcode.in/frame");

            // Waiting for the page to load...
            await page.WaitForLoadStateAsync();


            // Taking Normal Screenshot...
            var PathToSave = GetProjectDirectory() + "/Screenshots/";
            await page.ScreenshotAsync(new()
            {
                Path = PathToSave + "Screenshot.png"
            });

            // Taking Full Page Screenshot...
            await page.ScreenshotAsync(new()
            {
                Path = PathToSave + "FullScreenshot.png",
                FullPage = true
            });

            // Taking Element Screenshot...
            await page.Locator("//nav[@aria-label='main navigation']").ScreenshotAsync(new()
            {
                Path = PathToSave + "ElementScreenshot.png"
            });
        }

        public String GetProjectDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            int binIndex = baseDirectory.IndexOf("\\bin\\", StringComparison.OrdinalIgnoreCase);
            return baseDirectory.Substring(0, binIndex);
        }   
    }
}
