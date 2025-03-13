using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
