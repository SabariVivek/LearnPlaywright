using Microsoft.Playwright;

namespace LearnPlaywright
{
    public class DriverImplentation
    {
        private readonly Driver _driver;

        public DriverImplentation(Driver driver)
        {
            _driver = driver;
        }

        [Test]
        public async Task TestWithoutDriverImplementationAsync()
        {
            // URL Launching...
            await _driver.Page.GotoAsync("http://eaapp.somee.com/");

            // Other operations...
            await _driver.Page.Locator("id=loginLink").ClickAsync();
            await _driver.Page.Locator("id=UserName").FillAsync("admin");
            await _driver.Page.Locator("id=Password").FillAsync("password");
            await _driver.Page.Locator("xpath=//input[@value='Log in']").ClickAsync();

            // Page Verfication after logged in...
            await Assertions.Expect(_driver.Page.GetByText("Log off", new() { Exact = true })).ToBeVisibleAsync();
        }
    }
}
