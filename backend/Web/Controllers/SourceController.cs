using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("[controller]")]
    public class SourceController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();
    }
}
