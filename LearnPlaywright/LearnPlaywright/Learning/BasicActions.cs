using Microsoft.Playwright;

namespace LearnPlaywright.Learning
{
    internal class BasicActions
    {
        [Test]
        public async Task BasicActionsTest()
        {
            // Browser Configurations...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://omayo.blogspot.com");

            // Entering the text...
            await page.Locator("#ta1").FillAsync("Sabari Vivek");

            // Checkbox - Functionalities...
            await Assertions.Expect(page.Locator("#checkbox1")).ToBeCheckedAsync();
            await Assertions.Expect(page.Locator("#checkbox2")).Not.ToBeCheckedAsync();
            await page.Locator("#checkbox2").ClickAsync();

            // Radio Button - Functionalities...
            await page.Locator("#radio1").ClickAsync();
            await Assertions.Expect(page.Locator("#radio1")).ToBeCheckedAsync();
            await Assertions.Expect(page.Locator("#radio2")).Not.ToBeCheckedAsync();

            // Dropdown Functionalities...
            await page.Locator("#drop1").SelectOptionAsync("doc 2");

            // Multi Selection Dropdown...
            await page.Locator("#multiselect1").SelectOptionAsync(new[] { "Swift", "Audi" });

            // Single Click - Mouse Action...
            await page.GetByText("Volvo").ClickAsync();

            // Double Click - Mouse Action...
            await page.GetByText("Double click Here").ClickAsync();
            page.Dialog += (_, dialog) => dialog.AcceptAsync();

            // Hover - Mouse Action...
            await page.Locator("#blogsmenu").HoverAsync();

            // Right Click - Mouse Action...
            await page.Locator("#blogsmenu").ClickAsync(new() { Button = MouseButton.Right });
            await page.Locator("#blogsmenu").PressAsync("Escape");

            // Performing copy pase action...
            await page.Locator("#pah").DblClickAsync();
            await page.Locator("#pah").PressAsync("Control+C");
            await page.Locator("//textarea[not(@id)]").ClearAsync();
            await page.Locator("//textarea[not(@id)]").PressAsync("Control+V");

            await page.WaitForTimeoutAsync(3000);
        }
    }
}