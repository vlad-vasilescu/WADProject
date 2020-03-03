using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WADProject.Controllers
{
    public class AccountsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}