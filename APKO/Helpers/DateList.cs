using System.Collections.Generic;
using APKO.Models;
using APKO.Resources.Views.Admin.Shared;

namespace APKO.Helpers
{
    public class DateList
    {
        public static List<DropDownList> GetDateList()
        {
            return new List<DropDownList>
                       {
                          new DropDownList { Text = DateListItems.Yesterday, Value = DateConsts.Yesterday },
                          new DropDownList { Text = DateListItems.Week, Value = DateConsts.Week },
                          new DropDownList { Text = DateListItems.Mounth, Value = DateConsts.Month },
                       };
        }
    }
}