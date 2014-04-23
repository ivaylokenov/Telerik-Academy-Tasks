using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Data.Mappings;
using TasksManager.Models;

namespace TasksManager.Data
{
    public class TasksManagerDbContext : DbContext
    {
        public TasksManagerDbContext()
            : base("TasksManagerDb")
        {
        }

        public IDbSet<Appointment> Appointments { get; set; }
        public IDbSet<State> States { get; set; }
        public IDbSet<Todo> Todos { get; set; }
        public IDbSet<TodoList> TodoLists { get; set; }
        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppointmentMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new TodoListMap());
            modelBuilder.Configurations.Add(new TodoMap());
            modelBuilder.Configurations.Add(new UserMap());


            base.OnModelCreating(modelBuilder);
        }
    }
}
