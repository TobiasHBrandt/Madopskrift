using Madopskrift.Data;
using Madopskrift.Models;
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

        [HttpGet("{Id}")]
        public IActionResult GetOpskriften(int id)
        {
            MadopskriftDbContext visOpskrift = _context;
            // den laver en query select på Opskrift som ville hente kolonner
            Opskrift opskrift = visOpskrift.Opskrift.Select(a => new Opskrift
            {
                // sætter opskrift værdier til at være lig med a parameter
                Id = a.Id,
                BrugerId = a.BrugerId,
                Titel = a.Titel,
                Beskrivelse = a.Beskrivelse,
                Ingredienser = a.Ingredienser,
                Fremgangsmoede = a.Fremgangsmoede
                // den tjekker om det indeholder en id hvis den gør ville den vælge første id
            }).Where(a => a.Id == id).FirstOrDefault();

            if (opskrift == null)
            {
                return NotFound();
            }

            return Ok(opskrift);
        }

        [HttpPost]

        public IActionResult PostOpskrift(Opskrift opskrift)
        {
            var PostOpskrift = _context;
            if (PostOpskrift != null)
            {
                _context.Opskrift.Add(opskrift);
                _context.SaveChanges();
                return Ok("tilfoej opskrift");
            }
            else
            {
                return NotFound("Not added");
            }

        }

        [HttpPut("{id}")]
        public IActionResult PutOpskrift(int id, Opskrift opskrift)
        {
            // en lokal variable
            MadopskriftDbContext putOpskrift = _context;

            // den tjekker om det indeholder en id hvis den gør ville den vælge første id
            Opskrift existingOpskrift = putOpskrift.Opskrift.Where(o => o.Id == id).FirstOrDefault();

            // tjekker om opskrift ikke er null
            if (existingOpskrift != null)
            {
                // sætter existingOpskrift til at være lig med opskrift
                existingOpskrift.Titel = opskrift.Titel;
                existingOpskrift.Beskrivelse = opskrift.Beskrivelse;
                existingOpskrift.Ingredienser = opskrift.Ingredienser;
                existingOpskrift.Fremgangsmoede = opskrift.Fremgangsmoede;

                // den vil gemme opdateringen og returnere en Ok
                putOpskrift.SaveChanges();
                return Ok();
            }
            // hvis opskrift er en null værdi ville den ikke opdatere opskrift
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteOpskrift(int id)
        {
            // lokal variable
            MadopskriftDbContext putOpskrift = _context;
            // den tjekker om det indeholder en id hvis den gør ville den vælge første id
            var existingOpskrift = putOpskrift.Opskrift.Where(o => o.Id == id).FirstOrDefault();

            // tjekker om opskrift ikke er null
            if (existingOpskrift != null)
            {
                // ville slette opskrift og gemme 
                putOpskrift.Opskrift.Remove(existingOpskrift);
                putOpskrift.SaveChanges();
                // returnere en Ok
                return Ok();
            }
            // hvis opskrift er en null værdi ville den ikke slette opskrift
            else
            {
                return NotFound();
            }
        }

    }
}
