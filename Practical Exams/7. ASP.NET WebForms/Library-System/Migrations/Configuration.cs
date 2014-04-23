namespace WebFormsTemplate.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebFormsTemplate.Models.LibrarySystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebFormsTemplate.Models.LibrarySystemDbContext context)
        {
            this.SeedCategoriesAndBooks(context);
        }

        private void SeedCategoriesAndBooks(Models.LibrarySystemDbContext context)
        {
            for (int i = 0; i < 25; i++)
            {
                context.Categories.Add(new Models.Category
                {
                    Name = "Category " + i,
                    Books = new HashSet<Models.Book>
                    {
                        new Models.Book 
                        {
                            Title = "Book " + i + " First",
                            ISBN = "Some ISBN",
                            Description = "Some stupid book",
                            Authors = "Some stupid authors"
                        },
                        new Models.Book 
                        {
                            Title = "Book " + i + " Second",
                            WebSite = "http://somesite.com",
                            Description = "Some stupid book",
                            Authors = "Some stupid authors"
                        },
                        new Models.Book 
                        {
                            Title = "Book " + i + " Third",
                            ISBN = "Some ISBN",
                            WebSite = "http://somesite.com",
                            Authors = "Some stupid authors"
                        }
                    }
                });
            }

            context.SaveChanges();
        }
    }
}
