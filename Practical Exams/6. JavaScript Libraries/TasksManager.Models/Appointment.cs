using System;

namespace TasksManager.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int Duration { get; set; }

        public int OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public int StateId { get; set; }

        public virtual State State { get; set; }
    }
}