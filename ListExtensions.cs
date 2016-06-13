using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_DFP_Params
{
    public static class ListExtensions
    {
        public static void AddMany(this List<string> list, params string[] pages )
        {
            list.AddRange(pages);
        }
    }
}
