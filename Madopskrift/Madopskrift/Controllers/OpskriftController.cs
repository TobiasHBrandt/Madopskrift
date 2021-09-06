using Madopskrift.Data;
using Madopskrift.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        [HttpGet("{Id}")]
        public IActionResult GetOpskriften(int id)
        {
            var opskrift = _context.Opskrift.Select(a => new Opskrift
            {
                Id = a.Id,
                BrugerId = a.BrugerId,
                Titel = a.Titel,
                Beskrivelse = a.Beskrivelse,
                Ingredienser = a.Ingredienser,
                Fremgangsmåde = a.Fremgangsmåde
            }).Where(a => a.Id == id).FirstOrDefault();

            if (opskrift == null)
            {
                return NotFound();
            }

            //return new JsonResult(opskrift);
            return Ok(opskrift);
        }

    }
}
