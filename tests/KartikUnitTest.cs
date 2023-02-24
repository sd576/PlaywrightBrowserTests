using Microsoft.Playwright;

namespace PlaywrightTests;


public class KartikUnitTest
{
    [Test]
    public async Task Test1()
    {
        // dotnet test --filter "Test1"
        {
            // playwright
            using var playright = await Playwright.CreateAsync();

            // browser
            await using var browser = await playright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

            // page
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://eaapp.somee.com");
            await page.ClickAsync("text=Login");

            await page.FillAsync("#UserName", "admin");
            await page.FillAsync("#Password", "password");
            await page.ClickAsync("text=Log in");

            var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
            Assert.IsTrue(isExist);
        }
    }
}