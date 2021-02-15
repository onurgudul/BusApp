using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Core.Abstract;

namespace TepeBusApp.Core.Concreate
{
    public class Repository<T, TContext> : IRepository<T>
        where T : class, new()
        where TContext : DbContext, new()
    {
        public void Create(T Entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(Entity);
                context.SaveChanges();
            }
        }

        public void Delete(T Entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(Entity);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        public void Update(T Entity)
        {
            using (var context = new TContext())
            {
                context.Entry(Entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
