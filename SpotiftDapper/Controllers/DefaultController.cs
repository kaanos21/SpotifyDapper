using Microsoft.AspNetCore.Mvc;

namespace SpotiftDapper.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
