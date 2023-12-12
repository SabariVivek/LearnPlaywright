using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class FileUploadAndDownload
    {
        [Test]
        public async Task FileUploadAndDownloadTest()
        {
            // Browser Configurations...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();

            // File Upload...
            await page.GotoAsync("https://demo.guru99.com/test/upload/");
            await page.Locator("#uploadfile_0").SetInputFilesAsync(GetProjectDirectory() + "\\Resources\\Sample.txt");
            await page.Locator("#terms").ClickAsync();
            await page.Locator("#submitbutton").ClickAsync();
            await Assertions.Expect(page.Locator("//h3[@id='res']/center")).ToContainTextAsync("successfully uploaded", new() { IgnoreCase = true });

            // File Download - In a desired Location...
            await page.GotoAsync("https://eternallybored.org/misc/wget/");
            var waitForDownloadTask = page.WaitForDownloadAsync();
            await page.Locator("//td[text()='1.13']/following-sibling::td/a").ClickAsync();
            var download = await waitForDownloadTask;
            await download.SaveAsAsync(GetProjectDirectory() + "/DownloadedFiles/" + download.SuggestedFilename);

            await page.WaitForTimeoutAsync(3000);
        }

        public String GetProjectDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            int binIndex = baseDirectory.IndexOf("\\bin\\", StringComparison.OrdinalIgnoreCase);
            return baseDirectory.Substring(0, binIndex);
        }
    }
}
