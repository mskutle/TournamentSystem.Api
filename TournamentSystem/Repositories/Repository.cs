using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentSystem.Interfaces;
using TournamentSystem.Models;

namespace TournamentSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();
        }
    }
}