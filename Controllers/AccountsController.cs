using Microsoft.AspNetCore.Mvc;

namespace WADProject.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}