using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;

namespace NewsPortal.DataAccess
{
  public class NewsPortalDBContext : DbContext
  {
    public NewsPortalDBContext(DbContextOptions<NewsPortalDBContext> dbContextOptions)
      : base(dbContextOptions)
    {

    }
    public DbSet<Article> Article { get; set; }
    public DbSet<Category> EnumCategory { get; set; }
  }
}
