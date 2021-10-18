using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = null;
            string url = "http://localhost:64762/Account/Login";
            driver = new ChromeDriver(@"C:\DoverCorp");
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(5000);
            IWebElement username = driver.FindElement(By.Name("Email"));
            username.SendKeys("n@gmail.com");
            Thread.Sleep(2000);
            IWebElement password = driver.FindElement(By.Name("Password"));
            password.SendKeys("Nj@123$");
            Thread.Sleep(2000);
            IWebElement login = driver.FindElement(By.Id("login"));
            login.SendKeys(Keys.Enter);
           

        }
    }
}
