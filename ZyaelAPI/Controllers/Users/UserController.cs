using Microsoft.AspNetCore.Mvc;

namespace ZyaelAPI.Controllers.Users
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
