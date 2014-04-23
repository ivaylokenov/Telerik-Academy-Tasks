using System;
using System.Collections.Generic;

namespace TasksManager.Models
{
    public class TodoList
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public int OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }
}