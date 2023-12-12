using Microsoft.Playwright;

namespace LearnPlaywright.Learning.PageObjectModel
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly ILocator _userName, _password, _submit, _dashboardIdentifier;
        
        public LoginPage(IPage page)
        {
            _page = page;
            _userName = page.Locator("#username");
            _password = page.Locator("#password");
            _submit = page.Locator("#submit");
            _dashboardIdentifier = page.GetByText("Logged In Successfully");
        }

        public async Task GoToAsync()
        {
            await _page.GotoAsync("https://practicetestautomation.com/practice-test-login/");
        }

        public async Task LoginAsync(String Username, String Password)
        {
            await _userName.FillAsync(Username);
            await _password.FillAsync(Password);
            await _submit.ClickAsync();
        }

        public async Task SuccessfullLoginVerificationAsync()
        {
            await Assertions.Expect(_dashboardIdentifier).ToContainTextAsync("Logged In Successfully");
            await _page.WaitForTimeoutAsync(3000);
        }
    }
}
