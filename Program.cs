using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_DFP_Params
{
    class Program
    {
        static void Main(string[] args)
        {                                         
        }

        [SetUp]
        public void Initialize()
        {
            //You only need to provide details here specific to the website
            Driver.StartUp(Drivers.Chrome);
            var collections = new Collections();
            Collections.url = "http://www.birdwatching.co.uk/";
            Collections.expected_DFP_site = "SLEISURE/SLEI_Bird-Watching";
            Collections.ExpectedAccountId = 15356;
            Collections.ExpectedZoneIdMobile = 448686;
            Collections.ExpectedZoneIdDesktop = 448684;
            Collections.ExpectedSiteIdMobile = 95502;
            Collections.ExpectedSiteIdDesktop = 95500;
            Collections.pages.AddMany("gear-reviews", "video-1");
            Collections.driver.Navigate().GoToUrl(Collections.url);
        }

        [Test]
        public void DFPSite_ExpectToBeRightValue()
        {
            var homepage_dfp_site = Collections.driver.GetDFPParams("dfp_site");
            Assert.AreEqual(Collections.expected_DFP_site, homepage_dfp_site);
            Console.WriteLine($"DFP_Site for homepage:   {homepage_dfp_site}");

            foreach (string page in Collections.pages)
            {
                Collections.driver.Navigate().GoToUrl($"{Collections.url}{page}");
                var dfp_site = Collections.driver.GetDFPParams("dfp_site");
                Assert.AreEqual(Collections.expected_DFP_site, dfp_site);
                Console.WriteLine($"DFP_site for ({page}):   {dfp_site}");
            }
        }

        [Test]
        public void DFPPage_ExpectToBeRightValue()
        {
            //Only for homepage:
            var dfp_homepage = Collections.driver.GetDFPParams("dfp_page");
            Assert.AreEqual("homepage", dfp_homepage);
            Console.WriteLine($"DFP_Page for homepage:   {dfp_homepage}");


            foreach (string page in Collections.pages)
            {
                Collections.driver.Navigate().GoToUrl($"{Collections.url}{page}");
                var dfp_page = Collections.driver.GetDFPParams("dfp_page");
                Assert.AreEqual(page, dfp_page);
                Console.WriteLine($"DFP_Page for ({page}):   {dfp_page}");
            }
        }

        [Test]
        public void AccountId_ExpectToBeCorrect()
        {
            int accountId = Collections.driver.GetIds(IDs.accountId);
            Assert.AreEqual(Collections.ExpectedAccountId, accountId);
            Console.WriteLine($"Account Id for {Collections.expected_DFP_site}:   {accountId}");
        }

        [Test]
        public void MobileZoneId_ExpectToBeCorrect()
        {
            int mobileZoneId = Collections.driver.GetIds(IDs.mobileZoneId);
            Assert.AreEqual(Collections.ExpectedZoneIdMobile, mobileZoneId);
            Console.WriteLine($"Mobile Zone Id for {Collections.expected_DFP_site}:   {mobileZoneId}");
        }

        [Test]
        public void DesktopZoneId_ExpectToBeCorrect()
        {
            int desktopZoneId = Collections.driver.GetIds(IDs.desktopZoneId);
            Assert.AreEqual(Collections.ExpectedZoneIdDesktop, desktopZoneId);
            Console.WriteLine($"Desktop zone Id for {Collections.expected_DFP_site}:   {desktopZoneId}");
        }

        [Test]
        public void MobileSiteId_ExpectToBeCorrect()
        {
            int mobileSiteId = Collections.driver.GetIds(IDs.mobileSiteId);
            Assert.AreEqual(Collections.ExpectedSiteIdMobile, mobileSiteId);
            Console.WriteLine($"Mobile site Id for {Collections.expected_DFP_site}:   {mobileSiteId}");
        }

        [Test]
        public void DesktopSiteId_ExpectToBeCorrect()
        {
            int desktopSiteId = Collections.driver.GetIds(IDs.desktopSiteId);
            Assert.AreEqual(Collections.ExpectedSiteIdDesktop, desktopSiteId);
            Console.WriteLine($"Desktop site Id for {Collections.expected_DFP_site}:   {desktopSiteId}");
        }

        [TearDown]
        public void Close()
        {
            Collections.driver.Close();
        }
    }
}
