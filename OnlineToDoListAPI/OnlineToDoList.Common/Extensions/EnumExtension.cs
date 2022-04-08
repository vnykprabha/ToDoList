using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using OnlineToDoList.Common.Enums;

namespace OnlineToDoList.Common.Extensions
{
    public static class EnumExtension
    {
        public static string ToDescriptionString(this OnlinToDoListEnum.Result val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
