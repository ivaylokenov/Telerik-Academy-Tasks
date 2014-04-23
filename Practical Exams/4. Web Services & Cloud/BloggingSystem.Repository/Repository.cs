namespace BloggingSystem.Repository
{
    using BloggingSystem.Data;
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository()
        {
            // TODO: Add Dependancy Resolver... Otherwise - hack it like this :)

            this.Context = new BlogEntities();
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public T Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(item);
            }

            this.Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }

            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Update(int id, T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(item);
            }

            entry.State = EntityState.Modified;

            this.Context.SaveChanges();
        }

        // TODO: Remove SaveChanges in code
        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
