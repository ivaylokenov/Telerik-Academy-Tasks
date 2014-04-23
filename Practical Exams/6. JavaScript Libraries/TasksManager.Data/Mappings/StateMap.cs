using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Models;

namespace TasksManager.Data.Mappings
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            this.HasKey(a => a.Id);

            this.Property(a => a.Value)
                    .IsRequired()
                    .HasMaxLength(30);
        }
    }
}
