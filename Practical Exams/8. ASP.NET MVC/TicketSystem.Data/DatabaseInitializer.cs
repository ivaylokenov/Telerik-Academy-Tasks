namespace TicketSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TicketSystem.Model;

    public sealed class DatabaseInitializer : DbMigrationsConfiguration<TicketDbContext>
    {
        public DatabaseInitializer()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TicketDbContext context)
        {
            this.AddUserAndAdmin(context);
            this.AddData(context);
        }

        private void AddUserAndAdmin(TicketDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var user = new Author()
            {
                UserName = "username",
                Points = 10,
                Logins = new Collection<UserLogin>()
                {
                    new UserLogin()
                    {
                        LoginProvider = "Local",
                        ProviderKey = "username",
                    }
                },
                Roles = new Collection<UserRole>()
            };

            context.Users.Add(user);
            context.UserSecrets.Add(new UserSecret("username",
                "ACQbq83L/rsvlWq11Zor2jVtz2KAMcHNd6x1SN2EXHs7VuZPGaE8DhhnvtyO10Nf5Q==")); //admin123

            var userAdmin = new Author()
            {
                UserName = "admin",
                Points = 10,
                Logins = new Collection<UserLogin>()
                {
                    new UserLogin()
                    {
                        LoginProvider = "Local",
                        ProviderKey = "admin",
                    }
                },
                Roles = new Collection<UserRole>()
                {
                    new UserRole()
                    {
                        Role = new Role("Admin")
                    }
                }
            };

            context.Users.Add(userAdmin);
            context.UserSecrets.Add(new UserSecret("admin",
                "ACQbq83L/rsvlWq11Zor2jVtz2KAMcHNd6x1SN2EXHs7VuZPGaE8DhhnvtyO10Nf5Q==")); //admin123
            context.SaveChanges();
        }

        private void AddData(TicketDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var user = context.Users.FirstOrDefault();

            context.Categories.Add(new Category
            {
                Name = "Web",
                Tickets = new HashSet<Ticket>
                {
                    new Ticket
                    {
                        Author = user,
                        Description = "Error bace",
                        Priority = Priority.Low,
                        ScreenshotUrl = "/Content/image.png",
                        Title = "Problem occured",
                    },
                    new Ticket
                    {
                        Author = user,
                        Description = "Error bace 2",
                        Priority = Priority.Low,
                        ScreenshotUrl = "/Content/image.png",
                        Title = "Problem occured 2",
                    },
                    new Ticket
                    {
                        Author = user,
                        Description = "Error bace 3",
                        Priority = Priority.Low,
                        ScreenshotUrl = "/Content/image.png",
                        Title = "Problem occured 3",
                    },
                    new Ticket
                    {
                        Author = user,
                        Description = "Error bace 4",
                        Priority = Priority.Low,
                        ScreenshotUrl = "/Content/image.png",
                        Title = "Problem occured 4",
                    },
                }
            });

            context.Categories.Add(new Category
            {
                Name = "Data",
                Tickets = new HashSet<Ticket>
                {
                    new Ticket
                    {
                        Author = user,
                        Description = "Data bace",
                        Priority = Priority.Low,
                        ScreenshotUrl = "/Content/image.png",
                        Title = "Data occured",
                    },
                    new Ticket
                    {
                        Author = user,
                        Description = "Data bace 2",
                        Priority = Priority.Low,
                        ScreenshotUrl = "/Content/image.png",
                        Title = "Data occured 2",
                    },
                    new Ticket
                    {
                        Author = user,
                        Description = "Data bace 3",
                        Priority = Priority.Low,
                        ScreenshotUrl = "/Content/image.png",
                        Title = "Data occured 3",
                    },
                    new Ticket
                    {
                        Author = user,
                        Description = "Data bace 4",
                        Priority = Priority.Low,
                        ScreenshotUrl = "/Content/image.png",
                        Title = "Data occured 4",
                    },
                }
            });

            context.SaveChanges();
        }
    }
}
