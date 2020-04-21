using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStuff
{
    public class Selenium
    {
        private IWebDriver driver;
        private WebDriverWait wait;
            public Selenium(string s = "") {
            if (s == "headless")
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("headless");
                driver = new ChromeDriver(options);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            }
            else {
                driver = new ChromeDriver();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            }    
        }

        public void GoToUrl(string url) {
            driver.Navigate().GoToUrl(url);
        }

        public double Scrap(string JSCommand) {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            double price = 0;
            price = (double)js.ExecuteScript(JSCommand);
            return price;
        }

        public void Terminate() {
            driver.Quit();
        }

        public IWebDriver GetDriver() {
            return driver;
        }

        public void Wait(By element){
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }
    }
}
