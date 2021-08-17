using Madopskrift.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Madopskrift.Controllers
{
    [Route("api/opskrift")]
    [EnableCors("Policy")]
    [ApiController]
    public class OpskriftController : ControllerBase
    {
        private MadopskriftDbContext _context {get; }

        public OpskriftController(MadopskriftDbContext context)
        {
            _context = context;

        }

        [HttpGet]

        public IActionResult GetAllOpskrift()
        {
            return new JsonResult(_context.Opskrift);
        }

    }
}
