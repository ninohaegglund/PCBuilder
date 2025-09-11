using Microsoft.AspNetCore.Mvc;

namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    public class ComponentAPIController : Controller
    {
        public IActionResult Index()
        {   
            return View();
        }
    }
}
