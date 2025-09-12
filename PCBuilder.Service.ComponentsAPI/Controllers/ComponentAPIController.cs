using Microsoft.AspNetCore.Mvc;

namespace PCBuilder.Service.ComponentsAPI.Controllers;

public class ComponentAPIController : Controller
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        private readonly DataContext _db;

        public ComponentAPIController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<object> allComponents = _db.Computers.ToList();
            }
            catch (Exception ex)
            {

            }
        }
    }*/
}
