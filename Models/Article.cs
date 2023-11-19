using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPortal.Models
{
  public class Article
  {
    public int ArticleId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public DateTime CreatedDateTime { get; set; }
  }
}
