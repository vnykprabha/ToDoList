using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineToDoList.DTO.DTO
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
