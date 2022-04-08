using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OnlineToDoList.Common.Enums
{
    public static class OnlinToDoListEnum
    {        
        public enum Result
        {
            [Description("Success")]
            Success = 1,
            [Description("Failed")]
            Failed = 0
        }       
    }
}
