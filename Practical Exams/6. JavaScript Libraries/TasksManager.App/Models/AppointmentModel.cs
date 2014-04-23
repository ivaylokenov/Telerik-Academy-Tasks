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
    public class AppointmentModel
    {
        internal Appointment ToEntity()
        {
            return new Appointment()
            {
                Id = this.Id,
                Subject = this.Subject,
                Description = this.Description,
                CreationDate = DateTime.Now,
                AppointmentDate = DateTime.Parse(this.AppointmentDate),
                Duration = this.Duration
            };
        }

        public static Expression<Func<Appointment, AppointmentModel>> FromAppointment
        {
            get
            {
                return app =>
                new AppointmentModel()
                {
                    Id = app.Id,
                    Subject = app.Subject,
                    Description = app.Description,
                    CreationDate = app.CreationDate.ToShortDateString(),
                    AppointmentDate = app.AppointmentDate.ToShortDateString(),
                    Duration = app.Duration,
                    State = app.State.Value
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "createdAt")]
        public string CreationDate { get; set; }

        [DataMember(Name = "appointmentDate")]
        public string AppointmentDate { get; set; }

        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }
    }
}