using NewsPortal.Models;

namespace NewsPortal.Repositories
{
  public interface IArticleRepository
  {
    Task<Article> Create(Article article);

    Task<IEnumerable<Article>> GetArticles();

    Task<Article> Update(Article article);

    Task<bool> Delete(int articleId);

  }
}
