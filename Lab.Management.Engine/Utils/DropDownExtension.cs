using Lab.Management.Engine.Models;
using System.Collections.Generic;

namespace Lab.Management.Engine.Utils
{
    public static class DropDownExtension
    {
        public static IList<DropDown> GetBookingStatus()
        {
            var dropDown = new List<DropDown>
            {
                    new DropDown { Key = "Confirmed", Value = "CONFIRMED" },
                    new DropDown { Key = "Canceled", Value = "CANCELED" },
                    new DropDown { Key = "Completed", Value = "COMPLETED" }
            };
            return dropDown;
        }
    }
}