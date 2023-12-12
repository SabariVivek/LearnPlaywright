using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class DragAndDrop
    {
        [Test]
        public async Task DragAndDropTest()
        {
            // Browser & Page Configuration...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            }); 

            // URL Launching...
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://www.leafground.com/drag.xhtml");

            // Drag and Drop - With two elements...
            await page.Locator("//div[@id='form:drag_content']").DragToAsync(page.Locator("//div[@id='form:drop']"));

            await page.WaitForTimeoutAsync(3000);
        }
    }
}
