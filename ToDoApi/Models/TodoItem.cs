﻿using System;
namespace ToDoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
