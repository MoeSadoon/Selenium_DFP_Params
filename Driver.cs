using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium_DFP_Params
{
    public enum Drivers
    {
        Chrome,
        FireFox,
        IE,
        Safari
    }

    public static class Driver
    {
        public static void StartUp(Drivers driver)
        {
            string path = @"C:\Users\Moe\Desktop\WebDrivers";

            switch (driver)
            {
                case Drivers.Chrome:
                    Collections.driver = new ChromeDriver(path);
                    break;

                case Drivers.FireFox:
                    Collections.driver = new FirefoxDriver();
                    break;
            }
        }        
    }
}
