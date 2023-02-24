using Microsoft.Playwright;

namespace PlaywrightTests;


public class KartikPOMTest
{
    [Test]
    public async Task POMTest1()
    {
        // HEADED=1 dotnet test --filter "POMTest1"
        // PWDEBUG=1 dotnet test --filter "POMTest1"
        {
            // playwright
            using var playright = await Playwright.CreateAsync();

            // browser
            await using var browser = await playright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

            // page
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://eaapp.somee.com");

            LoginPage loginPage = new LoginPage(page);
            await loginPage.ClickLogin();
            await loginPage.Login("admin", "password");
            var isExist = await loginPage.IsEmployeeDetailsExists();
            Assert.IsTrue(isExist);
        }
    }
}