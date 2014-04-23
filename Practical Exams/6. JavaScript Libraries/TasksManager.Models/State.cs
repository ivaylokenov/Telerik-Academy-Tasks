using System.Collections.Generic;

namespace TasksManager.Models
{
    public class State
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}