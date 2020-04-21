using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;

namespace SeleniumStuff.Sources
{
    public static class TradingView
    {
        private static readonly string BaseUrl = "https://s.tradingview.com/bovespa/mediumwidgetembed/?symbols=";
        private static readonly By priceElement = By.CssSelector("[title='Last price']");
        private static readonly string JSCommand = "return parseFloat(document.getElementsByClassName('symbol-last')[0].firstChild.textContent) ";
        private static List<string> Itens;
        private static Selenium browser = new Selenium("headless");

        public static Dictionary<string, double> SearchItens(List<string> List)
        {
            Itens = List;
            
            Dictionary<string, double> FoundValues = new Dictionary<string, double>();
            foreach (string item in Itens)
            {
                try
                {
                    browser.GoToUrl(BaseUrl + item);
                    browser.Wait(priceElement);
                    for (int i = 0; i < 3; i++) {
                        double price = browser.Scrap(JSCommand);
                            FoundValues.Add(item, price);
                        if (price > 0)
                            break;
                        else
                            Thread.Sleep(1000);
                        }
                    } 
                catch (NoSuchElementException) {
                    FoundValues.Add("Falha ao carregar", 0);
                }
            }
                return FoundValues;
        }
        public static void terminate() {
            browser.Terminate();
        }
    }
}