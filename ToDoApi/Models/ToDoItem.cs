using System;

namespace ToDoApi.Models
{
    public class ToDoItem
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
