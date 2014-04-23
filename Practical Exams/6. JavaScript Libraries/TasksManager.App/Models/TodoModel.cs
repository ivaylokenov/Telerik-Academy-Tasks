using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;
using TasksManager.Models;

namespace TasksManager.App.Models
{
    [DataContract]
    public class TodoModel
    {
        public static Expression<Func<Todo, TodoModel>> FromTodo
        {
            get
            {
                return t =>
                new TodoModel()
                {
                    Id = t.Id,
                    Text = t.Text,
                    IsDone = t.IsDone
                };
            }
        }


        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "isDone")]
        public bool IsDone { get; set; }

        internal Todo ToEntity()
        {
            return new Todo()
            {
                Id = this.Id,
                Text = this.Text,
                IsDone = this.IsDone
            };
        }
    }
}