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
            var opskrift = _context.Opskrift.Select(a => new Opskrift
            {
                Id = a.Id,
                BrugerId = a.BrugerId,
                Titel = a.Titel,
                Beskrivelse = a.Beskrivelse,
                Ingredienser = a.Ingredienser,
                Fremgangsmoede = a.Fremgangsmoede
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
            using (var PostOpskrift = _context)
            {
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

        }

        [HttpPut("{id}")]
        public IActionResult PutOpskrift(int id, Opskrift opskrift)
        {
            using (var putOpskrift = _context)
            {
                var existingOpskrift = putOpskrift.Opskrift.Where(o => o.Id == id).FirstOrDefault<Opskrift>();

                if (existingOpskrift != null)
                {
                    existingOpskrift.Titel = opskrift.Titel;
                    existingOpskrift.Beskrivelse = opskrift.Beskrivelse;
                    existingOpskrift.Ingredienser = opskrift.Ingredienser;
                    existingOpskrift.Fremgangsmoede = opskrift.Fremgangsmoede;

                    putOpskrift.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok();

            }
            //var opskrift = _context.Opskrift.FirstOrDefault(Opskrift => Opskrift.BrugerId == id);
            //if (opskrift == null)
            //{
            //    return NotFound("ikke fundet");
            //}
            //if (opskrift.BrugerId == id)
            //{
            //    _context.Opskrift.Update(opskrift);
            //    _context.SaveChanges();
            //    return Ok(opskrift);
            //}
            //return BadRequest();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteOpskrift(int id)
        {
            using (var putOpskrift = _context)
            {
                var existingOpskrift = putOpskrift.Opskrift.Where(o => o.Id == id).FirstOrDefault<Opskrift>();

                if (existingOpskrift != null)
                {
                    putOpskrift.Opskrift.Remove(existingOpskrift);
                    putOpskrift.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

                

            }
        }

       


    }
}
