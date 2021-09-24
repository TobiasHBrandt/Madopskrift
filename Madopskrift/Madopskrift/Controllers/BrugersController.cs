using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Madopskrift.Data;
using Madopskrift.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Configuration;

namespace Madopskrift.Controllers
{
    // tilføjer en url sti til controlleren
    [Route("api/Bruger")]
    // tillader at kunne sende data frem og tilbage
    [EnableCors("Policy")]
    [ApiController]
    public class BrugersController : Controller
    {
        // _context læser fra dbcontext
        private readonly MadopskriftDbContext _context;
       
        // constrocter med en parameter
        public BrugersController(MadopskriftDbContext context)
        {
            _context = context;
            
        }

        // GET: Brugers
        [HttpGet]
        public IActionResult GetAllBruger()
        {
            return new JsonResult(_context.Brugers);
        }

        // GET: Brugers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruger = await _context.Brugers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bruger == null)
            {
                return NotFound();
            }

            return View(bruger);
        }

        // GET: Brugers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brugers/Create
        
        [HttpPost]

        public ActionResult PostBruger(Bruger bruger)
        {
            // en lokal variable
            MadopskriftDbContext PostBruger = _context;

            // tjækker om brugeren ikke er null
            if (PostBruger != null)
            {
                // ville den tiljøje og gemme brugeren hvor den returnere en ok
                PostBruger.Brugers.Add(bruger);
                PostBruger.SaveChanges();
                return Ok("tilfoej bruger");
            }

            // hvis brugeren er en null værdi ville den ikke tilføje brugeren
            else
            {
                return NotFound("Not added");
            }

            //var existingBruger = PostBruger.Brugers.Where(o => o.Email == email.Email && o.Password == email.Password).FirstOrDefault();


            //if (PostBruger != null)
            //{
            //    PostBruger.Brugers.Add(existingBruger);
            //    PostBruger.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Bruger ON;");
            //    PostBruger.SaveChanges();
            //    PostBruger.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Bruger OFF;");
            //    return Ok("tilfoej bruger");
            //}

        }

        // GET: Brugers/Edit/5
        //[HttpPut]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bruger = await _context.Brugers.FindAsync(id);
        //    if (bruger == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(bruger);
        //}

        //// POST: Brugers/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Brugernavn,Alder,Email,Password")] Bruger bruger)
        //{
        //    if (id != bruger.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(bruger);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BrugerExists(bruger.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(bruger);
        //}

        //// GET: Brugers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bruger = await _context.Brugers
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (bruger == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bruger);
        //}

        //// POST: Brugers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var bruger = await _context.Brugers.FindAsync(id);
        //    _context.Brugers.Remove(bruger);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BrugerExists(int id)
        //{
        //    return _context.Brugers.Any(e => e.Id == id);
        //}
    }
}
