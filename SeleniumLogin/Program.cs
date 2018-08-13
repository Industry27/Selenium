using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Open chrome browser
            IWebDriver driver = new ChromeDriver(@"C:\chromedriver");

            //Go to the url
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //Enter username
            IWebElement username = driver.FindElement(By.XPath("//*[@id='UserName']"));
            username.SendKeys("hari");

            //Enter password
            IWebElement password = driver.FindElement(By.XPath("//*[@id='Password']"));
            password.SendKeys("123123");

            //Click on Login
            IWebElement login = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            login.Click();

            //Check if home page is displayed
            //String turnup = driver.FindElement(By.XPath("/html/body/div[3]/div/a")).Text;

            if (driver.FindElement(By.XPath("/html/body/div[3]/div/a")).Text == "TurnUp")
            {
                Console.WriteLine("logged in successfully, test passed");
            }
            else
            {
                Console.WriteLine("TurnUp text is not present, test failed");
            }
        }
    }
}
