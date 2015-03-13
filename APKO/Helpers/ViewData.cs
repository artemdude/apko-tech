using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APKO.Helpers
{
    public class ViewData
    {
        public static string IsNull(string data)
        {
                if(data == null)
                {
                    return "asas";
                }

                return data;
        }
    }
}
