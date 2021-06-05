using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace WeCommerce.Controllers
{
    public class CrearPdfController : Controller
    {
        public IActionResult Index()
        {
            return new ViewAsPdf("Index");
        }
    }
}
