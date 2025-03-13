using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
