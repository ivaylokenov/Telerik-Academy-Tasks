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
    public class TodolistModel
    {
        internal TodoList ToEntity()
        {
            var entity = new TodoList()
            {
                Id = this.Id,
                Title = this.Title,
                CreationDate = DateTime.Now,
                Todos = this.Todos.Select(todo => todo.ToEntity()).ToList()
            };
            return entity;
        }


        public static Expression<Func<TodoList, TodolistModel>> FromTodoList
        {
            get
            {
                return tl =>
                new TodolistModel()
                {
                    Id = tl.Id,
                    Title = tl.Title,
                    Todos = tl.Todos.AsQueryable().Select(TodoModel.FromTodo)
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
        
        [DataMember(Name = "todos")]
        public IEnumerable<TodoModel> Todos { get; set; }
    }
}