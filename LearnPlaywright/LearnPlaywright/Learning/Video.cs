using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class Video
    {
        static String PathToSave = GetProjectDirectory();

        [Test]
        public async Task VideoTest()
        {
            // Browser Configuration...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });

            // Context & Page Configuration
            var context = await browser.NewContextAsync(new() {
                RecordVideoDir = PathToSave + "/Videos/"
            });
            var page = await context.NewPageAsync();

            // URL Launching...
            await page.GotoAsync("https://letcode.in/frame");

            await page.FrameLocator("iframe[name='firstFr']").GetByPlaceholder("Enter name").FillAsync("Sabari");
            await page.FrameLocator("iframe[name='firstFr']").GetByPlaceholder("Enter email").FillAsync("Vivek");
            await page.FrameLocator("iframe[name='firstFr']").
                FrameLocator("//iframe[@src='innerFrame']").GetByPlaceholder("Enter email").FillAsync("sabari@gmail.com");
            await page.WaitForTimeoutAsync(2000);
        }

        public static String GetProjectDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            int binIndex = baseDirectory.IndexOf("\\bin\\", StringComparison.OrdinalIgnoreCase);
            return baseDirectory.Substring(0, binIndex);
        }
    }
}
