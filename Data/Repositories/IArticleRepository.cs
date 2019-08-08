using System.Collections.Generic;
using System.Threading.Tasks;
using ArticleApi.Models;

namespace ArticleApi.Data.Repositories
{
    public interface IArticleRepository : IRepositoryBase<Article>
    {
        Task<Article> GetById(int id);
        Task DeleteById(int id);
        Task<IEnumerable<Article>> Search(string text);
    }
}