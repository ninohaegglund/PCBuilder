using Microsoft.AspNetCore.Mvc;

namespace PCBuilder.Web.Controllers
{
    public class ComponentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
