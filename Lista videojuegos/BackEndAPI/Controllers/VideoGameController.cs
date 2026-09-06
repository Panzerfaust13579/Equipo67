using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    public class VideoGameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
