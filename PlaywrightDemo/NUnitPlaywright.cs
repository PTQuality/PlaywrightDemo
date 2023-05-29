using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo
{
    public class NUnitPlaywright : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("http://www.eaapp.somee.com");
        }

        [Test]
        public async Task Test1()
        {
            Page.SetDefaultTimeout(10);

            var linkLogin = Page.Locator("text=Login");
            await linkLogin.ClickAsync();
            await Page.ClickAsync("text=Login");
            await Page.FillAsync("#UserName", "admin");
            await Page.FillAsync("#Password", "password");
            var btnLogin = Page.Locator("input", new PageLocatorOptions()
            {
                HasTextString = "Log in"
            });
            //await Page.ClickAsync("text=Log in");
            await btnLogin.ClickAsync();
            await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
            {
                Timeout = 1
            });
        }
    }
}