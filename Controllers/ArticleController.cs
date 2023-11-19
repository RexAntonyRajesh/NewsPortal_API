using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Models;
using NewsPortal.Repositories;

namespace NewsPortal.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArticleController : ControllerBase
  {
    private readonly IArticleRepository _articleRepository;
    public ArticleController(IArticleRepository articleRepository)
    {
      _articleRepository = articleRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Article>> Get()
    {
      var result = await _articleRepository.GetArticles();

      return result;
    }

    [HttpPost]
    public async Task<Article> Post(Article article)
    {
      var result = await _articleRepository.Create(article);

      return result;
    }

    [HttpPut]
    public async Task<Article> Put(Article article)
    {
      var result = await _articleRepository.Update(article);

      return result;
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<bool> Delete(int id)
    {
      bool isdeleted = await _articleRepository.Delete(id);
      return isdeleted;
    }

  }
}
