using Microsoft.AspNetCore.Mvc;

namespace learning_aspdotnet.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
