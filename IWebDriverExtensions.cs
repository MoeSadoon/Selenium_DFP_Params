using OpenQA.Selenium;
using Selenium_DFP_Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_DFP_Params
{
    public enum IDs
    {
        accountId,
        desktopZoneId,
        mobileZoneId,
        desktopSiteId,
        mobileSiteId             
    }

    public static class IWebDriverExtensions
    {
        public static string GetDFPParams(this IWebDriver driver, string dfp_params)
        {
            IJavaScriptExecutor js = Collections.driver as IJavaScriptExecutor;
            string dfp_site = (string)js.ExecuteScript($"return {dfp_params}");
            return dfp_site;
        }        


        public static int GetIds (this IWebDriver driver, IDs id)
        {
            var Id_type = String.Empty;

            switch (id)
            {
                case IDs.accountId:
                    Id_type = "rubicon_accountId";
                    break;

                case IDs.mobileZoneId:
                    Id_type = "rubicon_zone_id_mobile";
                    break;

                case IDs.desktopZoneId:
                    Id_type = "rubicon_zone_id_desktop";
                    break;

                case IDs.mobileSiteId:
                    Id_type = "rubicon_site_id_mobile";
                    break;

                case IDs.desktopSiteId:
                    Id_type = "rubicon_site_id_desktop";
                    break;                                   
            }       
              
            IJavaScriptExecutor js = Collections.driver as IJavaScriptExecutor;
            int Id = Int32.Parse((string)js.ExecuteScript($"return gpt_config['{Id_type}']"));
            return Id;

        }
    }
}
