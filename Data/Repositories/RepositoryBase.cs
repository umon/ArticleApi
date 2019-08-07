using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArticleApi.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext context;
        public RepositoryBase(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression = null)
        {
            var query = context.Set<T>().AsNoTracking();

            return await (expression == null
                ? query.FirstOrDefaultAsync()
                : query.SingleOrDefaultAsync(expression));
        }

        public async Task<IEnumerable<T>> List(Expression<Func<T, bool>> expression = null)
        {
            var query = context.Set<T>().AsNoTracking();

            if (expression != null)
                query = query.Where(expression);

            return await query.ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}