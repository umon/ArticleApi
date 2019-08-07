using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArticleApi.Data.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Get(Expression<Func<T,bool>> expression = null);
        Task<IEnumerable<T>> List(Expression<Func<T,bool>> expression = null);
        Task<bool> SaveChanges(); 
    }
}