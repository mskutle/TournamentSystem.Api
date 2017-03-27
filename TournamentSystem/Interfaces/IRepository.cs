using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TournamentSystem.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        Task<T> GetAsync(int id);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);
    }
}