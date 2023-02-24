using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

public class KartikNunitTest : PageTest
{
    [SetUp]
    public async Task Setup() => await Page.GotoAsync("http://eaapp.somee.com");

    // HEADED=1 dotnet test --filter "NunitTest1"
    [Test]
    public async Task NunitTest1()
    {
        await Page.ClickAsync("text=Login");
        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        await Page.ClickAsync("text=Log in");
        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }
}