using Microsoft.Playwright;
using PlaywrightTests.Pages;

namespace PlaywrightTests;

public class KartikPOMUpgradedTest
{
    [Test]
    public async Task POMUpgradedTest1()
    {
        // HEADED=1 dotnet test --filter "POMUpgradedTest1"
        // PWDEBUG=1 dotnet test --filter "POMUpgradedTest1"
        {
            // playwright
            using var playright = await Playwright.CreateAsync();

            // browser
            await using var browser = await playright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

            // page
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://eaapp.somee.com");

            var loginPage = new LoginPageUpgraded(page);
            await loginPage.ClickLogin();
            await loginPage.Login("admin", "password");
            var isExist = await loginPage.IsEmployeeDetailsExists();
            Assert.IsTrue(isExist);
        }
    }
}