using Microsoft.Playwright;

namespace LearnPlaywright.Learning.PageObjectModel
{
    public class LoginTest
    {
        [Test]
        public async Task LoginMethod()
        {
            // Browser Initialization...
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();

            // Object creation for page class...
            LoginPage loginpage = new LoginPage(page);

            // Method calling...
            await loginpage.GoToAsync();
            await loginpage.LoginAsync("student", "Password123");
            await loginpage.SuccessfullLoginVerificationAsync();
        }
    }
}
