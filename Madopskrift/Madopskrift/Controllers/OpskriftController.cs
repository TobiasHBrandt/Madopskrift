﻿using Madopskrift.Data;
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

       


    }
}
