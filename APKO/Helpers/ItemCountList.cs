using System.Collections.Generic;

namespace APKO.Helpers
{
    public class ItemCountList
    {
        public static List<DropDownList> GetItemsCountList()
        {
            return new List<DropDownList>
                       {
                           new DropDownList { Text = "5", Value = 5 },
                           new DropDownList { Text = "10", Value = 10 },
                           new DropDownList { Text = "15", Value = 15 },
                           new DropDownList { Text = "20", Value = 20 },
                           new DropDownList { Text = "50", Value = 50 },
                           new DropDownList { Text = "All", Value = 0 }
                       };
        }
    }
}