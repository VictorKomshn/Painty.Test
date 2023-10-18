using Microsoft.AspNetCore.Mvc;

namespace Painty.Test.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
