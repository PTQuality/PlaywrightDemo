using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo
{
    public class NUnitPlaywright : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
        }

        [Test]
        public async Task Test1()
        {

            await Page.GotoAsync("http://www.eaapp.somee.com");
            await Page.ClickAsync("text=Login");
            await Page.FillAsync("#UserName", "admin");
            await Page.FillAsync("#Password", "password");
            await Page.ClickAsync("text=Log in");
            await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();

        }
    }
}