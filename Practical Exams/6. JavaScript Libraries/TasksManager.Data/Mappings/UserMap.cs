using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Models;

namespace TasksManager.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(u => u.Id);

            this.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(40);

            this.Property(u => u.Email)
                    .HasMaxLength(40)
                    .IsRequired();

            this.Property(u => u.AuthenticationCode)
                    .IsRequired()
                    .IsFixedLength()
                    .HasMaxLength(40);

            this.Property(u => u.AccessToken)
                    .IsFixedLength()
                    .HasMaxLength(50);
           
                                
        }
    }
}
