using Microsoft.AspNetCore.Mvc;

namespace Pi3CoreApi.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}