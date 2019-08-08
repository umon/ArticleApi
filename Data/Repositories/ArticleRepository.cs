using System.Collections.Generic;
using System.Threading.Tasks;
using ArticleApi.Models;

namespace ArticleApi.Data.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext context;
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task DeleteById(int id)
        {
            var article = await GetById(id);

            if (article != null)
            {
                Delete(article);
            }
        }

        public async Task<Article> GetById(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<IEnumerable<Article>> Search(string text)
        {
            return await List(x=>
                x.Author.Contains(text) || 
                x.Title.Contains(text) ||
                x.Content.Contains(text));
        }
    }
}