using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string AuthenticationCode { get; set; }
        public string AccessToken { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<TodoList> TodoLists { get; set; }

    }

}
