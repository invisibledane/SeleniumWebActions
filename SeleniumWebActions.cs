using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Selenium
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebActions
{
    class WebActions
    {
        // Currently in region:
        // 1. IE browser driver
        #region MemberVariables
        public static string m_IEdriverLocation = @"C:\YourDirectory"; // IEdriver.exe path

        #endregion

        #region WebDriverActions
        // Wait until an element before proceeding in the code
        public static bool WaitForElement(IWebDriver driver, string element, int seconds)
        {
            bool bReturn = true;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.Id(element));
                });
            }
            catch (TimeoutException timeout)
            {
                Assert.Inconclusive(String.Format("Support.WaitForElement Timeout Error! Wait for {0} timed out! {1}",
                    element, timeout.Message.ToString()));
                bReturn = false;
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.WaitForElement ERROR! Wait for '{1}' {0}", ex.Message.ToString().ToLower(), element));
            }

            return bReturn;
        }

        // Quit driver - dispose
        public static void DriverQuit(IWebDriver driver)
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(ex.Message.ToString());
            }
        }

        // Finds and returns a WebElement by ID
        public static IWebElement GetElementByID(IWebDriver driver, string elementID)
        {
            IWebElement returnElement = null;
            try
            {
                returnElement = driver.FindElement(By.Id(elementID));
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.GetElementByID error! {0}", ex.Message.ToString()));
            }

            return returnElement;
        }

        // Get Webelement by text
        public static IWebElement GetElementByLinkText(IWebDriver driver, string LinkText)
        {
            IWebElement iWebReturn = null;

            try
            {
                iWebReturn = driver.FindElement(By.LinkText(LinkText));
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.GetElementByLinkText ERROR! {0}", ex.Message.ToString()));
            }

            return iWebReturn;
        }

        // Pauses playback for a certain number of seconds
        // This is the method that should be included in Selenium but isn't
        public static void Pause(double seconds)
        {
            try
            {
                DateTime now = DateTime.Now;
                DateTime future = DateTime.Now.AddSeconds(seconds);
                while (now < future)
                {
                    now = DateTime.Now; // Not doin' shit
                }
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(ex.Message.ToString());
            }
        }

        // Click web element
        public static void ClickItem(IWebDriver driver, IWebElement item)
        {
            try
            {
                item.Click();
                Support.Pause(1);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(ex.Message.ToString());
            }
        }

        // Get text from a web element
        public static string GetText(IWebDriver driver, IWebElement element)
        {
            string sReturn = "";

            try
            {
                sReturn = element.Text;
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(string.Format("Support.GetText Error! {0}", ex.Message.ToString()));
            }

            return sReturn;
        }

        // Hover cursor over element
        public static void HoverCursorOverWebElement(IWebDriver driver, IWebElement element)
        {
            try
            {
                // hover like a helicopter!
                OpenQA.Selenium.Interactions.Actions builder =
                    new OpenQA.Selenium.Interactions.Actions(driver);       // GET TO DA CHOPPA'
                builder.MoveToElement(element).Build().Perform();           // I'M IN DA CHOPPA'
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.HoverCursorOverWebElement ERROR! {0}", ex.Message.ToString()));
            }
        }

        public static void SelectFromDDLEntryByArrowKey(IWebDriver driver, IWebElement DDL, int EntryIndex)
        {
            try
            {
                // Click on DDL
                ClickItem(driver, DDL);

                // Enter downkey set number of times
                int iCounter = 0;
                while (iCounter < EntryIndex)
                {
                    SendKeyDownArrow(DDL);
                    iCounter++;
                }
                SendKeyEnter(DDL);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.SelectDDLEntry ERROR! '{0}'", ex.Message.ToString()));
            }
        }

        // Selects an item from a dropdown list by the text entry.
        // Will basically send the text to the control
        public static void SelectFromDDLByText(IWebDriver driver, IWebElement Item, string Text)
        {
            try
            {
                Item.Click();
                Support.Pause(1);
                Item.SendKeys(Text);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.SelectFromDDLByText error! {0}", ex.Message.ToString()));
            }
        }

        // Send Enter key to an element
        public static void SendKeyEnter(IWebElement element)
        {
            try
            {
                element.SendKeys(Keys.Enter);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.SendKeyEnter ERROR! {0}", ex.Message.ToString()));
            }
        }

        // Send down key to an element
        public static void SendKeyDownArrow(IWebElement element)
        {
            try
            {
                element.SendKeys(Keys.ArrowDown);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.SendKeyDownArrow Error! {0}", ex.Message.ToString()));
            }
        }

        // Sends spacebar to a specific element
        public static void SendKeySpacebar(IWebElement element)
        {
            try
            {
                element.SendKeys(Keys.Space);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.SendKeyTAB ERROR! {0}", ex.Message.ToString()));
            }
        }

        // Sends tab key to a specific element
        public static void SendKeyTab(IWebElement element)
        {
            try
            {
                element.SendKeys(Keys.Tab);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.SendKeyTAB ERROR! {0}", ex.Message.ToString()));
            }
        }

        // Send up key to an element
        public static void SendKeyUpArrow(IWebElement element)
        {
            try
            {
                element.SendKeys(Keys.ArrowUp);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.SendKeyDownArrow Error! {0}", ex.Message.ToString()));
            }
        }

        // Send text to a textbox
        public static void SendText(IWebDriver driver, IWebElement element, string sText)
        {
            try
            {
                element.Clear();
                Support.Pause(.5);
                element.SendKeys(sText);
            }
            catch (Exception ex)
            {

                Assert.Inconclusive(ex.Message.ToString());
            }
        }

        // Go to a URL, return true if URL == passed URL, false if !passed URL
        public static bool GoToURL(IWebDriver driver, string URL)
        {
            bool bReturn = true;

            try
            {
                driver.Navigate().GoToUrl(URL);
                if (driver.Url != URL)
                {
                    bReturn = false;
                }
            }
            catch (UriFormatException uri)
            {
                Assert.Inconclusive(String.Format("Support.GoToURL Exception! Invalid URL! '{0}'", uri));
            }
            catch (Exception ex)
            {
                Assert.Inconclusive(String.Format("Support.GoToURL ERROR! {0}", ex.Message.ToString()));
                bReturn = false;
            }

            return bReturn;

        }
        #endregion

    }
}
