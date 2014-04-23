using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Models;

namespace TasksManager.Data.Mappings
{
    public class TodoMap : EntityTypeConfiguration<Todo>
    {
        public TodoMap()
        {
            this.HasKey(a => a.Id);

            this.Property(a => a.Text)
                    .IsRequired()
                    .HasMaxLength(40);

            this.Property(a => a.IsDone)
                    .IsRequired();

            this.Property(a => a.ListId)
                .IsRequired();
        }
    }
}
