using AutoMapper;
using BusinessLogicLayer.IService;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]    // [controller]/[action] can be used in place of ("GetCategory")
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        
    }
}
