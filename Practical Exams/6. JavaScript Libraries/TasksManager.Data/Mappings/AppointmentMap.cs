using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Models;

namespace TasksManager.Data.Mappings
{
    public class AppointmentMap : EntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
            this.HasKey(a => a.Id);

            this.Property(a => a.Subject)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(a => a.Description)
                .IsRequired()
                .HasColumnType("ntext");

            this.Property(a => a.CreationDate)
                .IsRequired();

            this.Property(a => a.AppointmentDate)
                .IsRequired();

            this.Property(a => a.OwnerId)
                .IsRequired();

            this.Property(a => a.StateId)
                .IsRequired();
        }
    }
}