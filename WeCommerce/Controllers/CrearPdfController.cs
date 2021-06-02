using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
