using APKO.Helpers.Constants;
using APKO.Resources.Views.Admin.Shared;


namespace APKO.Helpers
{
    public static class PublishOrEdit
    {
        public static string GetValue(string action)
        {

            if (action == ManageValues.Edit)
                {
                    return Buttons.Update;
                }

            if (action == ManageValues.New)
                {
                    return Buttons.Publish;
                }
        

            return "Error";
        }
    }
}