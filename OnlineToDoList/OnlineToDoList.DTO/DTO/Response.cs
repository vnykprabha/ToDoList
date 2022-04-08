using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineToDoList.DTO.DTO
{
    public class Response
    {
        public int ReturnValue { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
    }
}
