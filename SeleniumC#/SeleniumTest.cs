using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace SeleniumCsharp

{

    public class Tests

    {

        IWebDriver driver;

        [OneTimeSetUp]

        public void Setup()

        {

            //Below code is to get the drivers folder path dynamically.

            //You can also specify chromedriver.exe path dircly ex: C:/MyProject/Project/drivers

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            //Creates the ChomeDriver object, Executes tests on Google Chrome

            driver = new ChromeDriver(path + @"\drivers\");

            //If you want to Execute Tests on Firefox uncomment the below code

            // Specify Correct location of geckodriver.exe folder path. Ex: C:/Project/drivers

            //driver= new FirefoxDriver(path + @"\drivers\");

        }
         
        [Test]

        public void verifyKnowAboutUsButton()

        {
            // Verifies the presence of "Know about us" button in the first form

            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            ReadOnlyCollection<IWebElement> KnowAboutUs = driver.FindElements(By.XPath("//button[@class='btn btn-primary dropdown-toggle']"));
           
            Assert.AreEqual(KnowAboutUs.Count, 1);
        }


        [Test]

        public void verifyFormHeading()

        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            IWebElement formHeader = driver.FindElement(By.TagName("h2"));

            Assert.IsTrue(formHeader.Text.Contains("Form"));

        }


        [Test]

        public void cancelButtonRedirect()

        {
            // Verifies the redirection on clicking "Cancel" button

            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            driver.FindElement(By.XPath("//*[contains(., 'Cancel')]")).Click();
            var url = driver.Url;
            Assert.IsTrue(url.Contains("https://app.cloudqa.io"));
        }


        [OneTimeTearDown]

        public void TearDown()

        {

            driver.Quit();

        }

    }

}
