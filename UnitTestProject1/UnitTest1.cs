using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();// Creares a new Chrome instance and opens the brower
            driver.Navigate().GoToUrl("https://www.bbc.com");
            IWebElement element = driver.FindElement(By.XPath("//a[@href = 'https://www.bbc.com/news']"));
            element.Click();
            List<string>tempList = new List<string>();
             List<string> ERList = new List<string>()
             {

                 "Turkish diplomat shot dead in Iraqi Kurdistan",
                 "US congresswoman hit back at 'biggest bully' Trump"

             };

             tempList.Add(driver.FindElement(By.XPath("//a[@href='/news/world-middle-east-49020786']")).Text);
             tempList.Add(driver.FindElement(By.XPath("//a[@href='/news/world-us-canada-49012571']")).Text);
             Assert.AreEqual(tempList.Count, ERList.Count);
             for( var i=0; i<tempList.Count; i++)
             {
                 Assert.AreEqual(tempList[i], ERList[i]);
             }
                        
            IWebElement elHeadArticle = driver.FindElement(By.XPath("//*[@data-entityid='container-top-stories#1']/div/ul/li[2]/a"));


            string searchText = elHeadArticle.Text; 


            IWebElement searchFild = driver.FindElement(By.XPath("//*[@id='orb-search-q']"));
            searchFild.SendKeys(searchText);
            IWebElement searchButton = driver.FindElement(By.XPath("//*[@id='orb-search-button']"));
            searchButton.Click();

            string expectedArticle = "US & Canada";

            IWebElement article1 = driver.FindElement(By.XPath("//h1[@itemprop='headline']"));
            


            
            IWebElement actualLink = article1.FindElement(By.XPath("//*[@data-result-number='1']/article/div/h1/a "));
            string s = actualLink.Text;
            




            Assert.AreEqual(expectedArticle, s);
            driver.Quit();


        

            
 
            
                   }

        [TestMethod]
        public void TestMethod2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
             




        }
    }
}
