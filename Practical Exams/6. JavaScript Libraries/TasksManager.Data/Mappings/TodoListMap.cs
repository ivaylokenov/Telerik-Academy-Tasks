using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Models;

namespace TasksManager.Data.Mappings
{
    public class TodoListMap : EntityTypeConfiguration<TodoList>
    {
        public TodoListMap()
        {
            this.HasKey(tl => tl.Id);

            this.Property(tl => tl.Title)
                    .HasColumnName("Title")
                    .IsRequired()
                    .HasMaxLength(40);

            this.Property(tl => tl.CreationDate)
                    .HasColumnName("CreationDate")
                    .IsRequired();

            this.Property(tl => tl.OwnerId)
                .IsRequired();
        }
    }
}
