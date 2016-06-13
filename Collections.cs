using OpenQA.Selenium;
using System.Collections.Generic;

namespace Selenium_DFP_Params
{
    public class Collections
    {
        public static IWebDriver driver { get; set; }
        public static string url { get; set; }
        public static string expected_DFP_site { get; set; }
        public static int ExpectedAccountId { get; set; }
        public static int ExpectedZoneIdMobile { get; set; }
        public static int ExpectedZoneIdDesktop { get; set; }
        public static int ExpectedSiteIdMobile { get; set; }
        public static int ExpectedSiteIdDesktop { get; set; }
        public static List<string> pages = new List<string>();   
    }
}