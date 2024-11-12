using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UnitTest_Selenium
{
    public class BookingTest
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44386/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestBookNewProject()
        {
            driver.FindElement(By.Id("username")).SendKeys("testuser");
            driver.FindElement(By.Id("password")).SendKeys("password");
            driver.FindElement(By.Id("loginButton")).Click();

            driver.FindElement(By.Id("nav-booking")).Click();

            driver.FindElement(By.Id("projectName")).SendKeys("Thi cong ho ca Koi moi");
            driver.FindElement(By.Id("projectDate")).SendKeys("2024-11-15");
            driver.FindElement(By.Id("projectLocation")).SendKeys("tang nhan phu a, Quan 9, TP HCM");
            driver.FindElement(By.Id("submitBooking")).Click();

            var confirmationMessage = driver.FindElement(By.Id("confirmationMessage")).Text;
            Assert.AreEqual("Lich thi cong da duoc dat thanh cong!", confirmationMessage);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
