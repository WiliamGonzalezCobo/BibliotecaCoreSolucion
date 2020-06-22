using BibliotecaCore.Dal.Context;
using BibliotecaCore.Domain.Context;
using BibliotecaCore.Domain.Entities;
using BibliotecaCore.Domain.Specification;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BibliotecaCore.Domain.Repository
{


    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbLibraryContext context;
        private readonly DbSet<T> entities;
        private bool disposed = false;

        public Repository(DbLibraryContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll(Specification<T> specification)
        {
            Func<IQueryable<T>, IQueryable<T>> includes = DbContextHelper.GetNavigations<T>();
            IQueryable<T> query = context.Set<T>();
            if (includes != null)
            {
                query = includes(query);
            }
            return query.Where(specification.ToExpression());
        }

        public T Get(Specification<T> specification)
        {
            Func<IQueryable<T>, IQueryable<T>> includes = DbContextHelper.GetNavigations<T>();
            IQueryable<T> query = context.Set<T>();
            if (includes != null)
            {
                query = includes(query);
            }
            return query.Where(specification.ToExpression()).FirstOrDefault();
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            Func<IQueryable<T>, IQueryable<T>> includes = DbContextHelper.GetNavigations<T>();
            IQueryable<T> query = context.Set<T>();
            if (includes != null)
            {
                query = includes(query);
            }

            var entity = await query.FirstOrDefaultAsync(predicate);
            return entity;
        }
        public void Add(T entityDb)
        {
            context.Entry(entityDb).State = EntityState.Added;
        }

        public void Update(T entityDb)
        {
            context.Entry(entityDb).State = EntityState.Modified;
        }

        public void Delete(Object id)
        {
            T existing = entities.Find(id);
            entities.Remove(existing);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
