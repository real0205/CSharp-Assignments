using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    public class BlogController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
