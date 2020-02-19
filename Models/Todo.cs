using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public sbyte Status { get; set; }
        public int UserId { get; set; }
    }
}
