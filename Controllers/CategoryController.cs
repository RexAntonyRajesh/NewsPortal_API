using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Models;
using NewsPortal.Repositories;

namespace NewsPortal.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> Get()
    {
      var result = await _categoryRepository.GetCategories();

      return result;
    }
  }
}
