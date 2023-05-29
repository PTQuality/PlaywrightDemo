using Microsoft.Playwright;
using PlaywrightDemo.Pages;

namespace PlaywrightDemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            //Playwright 
            using var playwright = await Playwright.CreateAsync();
            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
            {
                Headless = false,
            });
            //Page
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://www.eaapp.somee.com");

            var loginPage = new LoginPageUpgraded(page);
            await loginPage.ClickLogin();
            await loginPage.Login("admin", "password");
            var isExist = await loginPage.IsEmployeeExist();
            Assert.IsTrue(isExist);

        }
    }
}