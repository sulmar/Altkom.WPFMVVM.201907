using SWOP.Transport.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SWOP.Transport.DbRepositories
{
    public class DbEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : class
    {
        protected readonly TransportContext context;

        public DbEntityRepository(TransportContext context)
        {
            this.context = context;
        }

        protected DbSet<TEntity> entities => context.Set<TEntity>();

        public void Add(TEntity entity)
        {
            Console.WriteLine(context.Entry(entity).State);
            entities.Add(entity);

            Console.WriteLine(context.Entry(entity).State);
            context.SaveChanges();

            Console.WriteLine(context.Entry(entity).State);
        }

        public virtual ICollection<TEntity> Get() => entities.ToList();

        public virtual TEntity Get(int id) => entities.Find(id);

        public virtual void Remove(int id)
        {
            TEntity entity = Get(id);

            Console.WriteLine(context.Entry(entity).State);

            entities.Remove(entity);

            Console.WriteLine(context.Entry(entity).State);

            context.SaveChanges();

            Console.WriteLine(context.Entry(entity).State);
        }

        public virtual void Update(TEntity entity)
        {
            Console.WriteLine(context.Entry(entity).State);

            context.Entry(entity).State = EntityState.Modified;

            Console.WriteLine(context.Entry(entity).State);

            var entries = context.ChangeTracker.Entries();

            context.SaveChanges();

            Console.WriteLine(context.Entry(entity).State);
        }
    }
}
