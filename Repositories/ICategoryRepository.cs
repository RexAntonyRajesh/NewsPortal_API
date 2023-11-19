using NewsPortal.Models;

namespace NewsPortal.Repositories
{
  public interface ICategoryRepository
  {
    Task<IEnumerable<Category>> GetCategories();
  }
}
