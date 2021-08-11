using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Madopskrift.Controllers
{
    public class OpskriftController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
