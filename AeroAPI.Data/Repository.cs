using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AeroAPI.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = entities.SingleOrDefault(i => i.Id == id);
            entities.Remove(entity ?? throw new InvalidOperationException("Invalid entity to delete."));
        }
    }
}
