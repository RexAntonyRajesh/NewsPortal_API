using Microsoft.EntityFrameworkCore;
using NewsPortal.DataAccess;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
  public class ArticleRepository : IArticleRepository
  {
    private readonly NewsPortalDBContext _dbContext;
    public ArticleRepository(NewsPortalDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<Article> Create(Article article)
    {
      var entity = new Article
      {
        CategoryId = article.CategoryId,
        Title = article.Title,
        Description = article.Description,
        CreatedDateTime = article.CreatedDateTime
      };

      var result = await _dbContext.AddAsync(entity);
      _dbContext.SaveChanges();

      return result.Entity;
    }

    public async Task<IEnumerable<Article>> GetArticles()
    {
      var result = await _dbContext.Article.OrderByDescending(a => a.CreatedDateTime).ToListAsync();

      return result;
    }

    public async Task<Article> Update(Article article)
    {
      var entity = await _dbContext.Article.SingleOrDefaultAsync(a => a.ArticleId == article.ArticleId);

      if (entity != null)
      {
        entity.CategoryId = article.CategoryId;
        entity.CreatedDateTime = article.CreatedDateTime;
        entity.Title = article.Title;
        entity.Description = article.Description;
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
      }

      return entity;
    }

    public async Task<bool> Delete(int articleId)
    {
      var entity = await _dbContext.Article.SingleOrDefaultAsync(a => a.ArticleId == articleId);
      if (entity != null)
      {
        _dbContext.Article.Remove(entity);
        _dbContext.SaveChanges();
        return true;
      }

      return false;
    }
  }
}
