using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WebFormsTemplate.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
    }

    // You can inherit the base IdentityContext and add your application custom DbSets
    public class LibrarySystemDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public LibrarySystemDbContext()
            : base("LibrarySystemConnection")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}