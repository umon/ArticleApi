using System;
using System.Threading.Tasks;
using ArticleApi.Data.Repositories;
using ArticleApi.Dtos;
using ArticleApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArticleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository articleRepository;
        private readonly IMapper mapper;

        public ArticlesController(IArticleRepository articleRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.articleRepository = articleRepository;
        }

        // GET api/articles
        // GET api/articles?search=umut%20onur
        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            search = search.Trim();

            if (!string.IsNullOrEmpty(search))
            {
                return Ok(await articleRepository.Search(search));
            }

            return Ok(await articleRepository.List());
        }

        // GET api/articles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var article = await articleRepository.GetById(id);

            if (article == null)
                return NotFound();

            return Ok(article);
        }

        // POST api/articles
        [HttpPost]
        public async Task<IActionResult> Post(ArticleCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = mapper.Map<Article>(model);

            article.CreatedDate = DateTime.Now;
            article.UpdatedDate = DateTime.Now;
            await articleRepository.Add(article);

            if (await articleRepository.SaveChanges())
            {
                return Ok(article);
            }

            return StatusCode(304);
        }

        // PUT api/articles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ArticleUpdateDto model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var article = await articleRepository.GetById(model.Id);

            if (article == null)
            {
                return NotFound();
            }

            mapper.Map(model, article);
            article.UpdatedDate = DateTime.Now;

            articleRepository.Update(article);

            if (await articleRepository.SaveChanges())
            {
                return Ok(article);
            }

            return StatusCode(304);
        }

        // DELETE api/articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await articleRepository.DeleteById(id);

            if (await articleRepository.SaveChanges())
            {
                return Ok();
            }

            return StatusCode(304);
        }
    }
}
