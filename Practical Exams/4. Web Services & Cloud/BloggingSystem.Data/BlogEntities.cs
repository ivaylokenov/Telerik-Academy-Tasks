namespace BloggingSystem.Data
{
    using BloggingSystem.Model;
    using System.Data.Entity;

    public class BlogEntities : DbContext
    {
        public BlogEntities() 
            : base("BlogSystem") 
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(usr => usr.SessionKey)
                .IsFixedLength()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(usr => usr.AuthCode)
                .IsFixedLength()
                .HasMaxLength(40);

            base.OnModelCreating(modelBuilder);
        }
    }
}
