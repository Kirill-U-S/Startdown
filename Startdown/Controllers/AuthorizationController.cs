using Microsoft.AspNetCore.Mvc;

namespace Startdown.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index() //при переходе по /Autorization
        {
            return View();
        }
    }
}
