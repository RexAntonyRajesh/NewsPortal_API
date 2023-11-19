using Microsoft.EntityFrameworkCore;
using NewsPortal.DataAccess;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly NewsPortalDBContext _dbContext;
    public CategoryRepository(NewsPortalDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
      var result = await _dbContext.EnumCategory.ToListAsync();

      return result;
    }
  }
}
