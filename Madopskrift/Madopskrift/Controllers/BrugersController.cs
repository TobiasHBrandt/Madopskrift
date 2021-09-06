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

namespace Madopskrift.Controllers
{

    [Route("api/Bruger")]
    [EnableCors("Policy")]
    [ApiController]
    public class BrugersController : Controller
    {
        private readonly MadopskriftDbContext _context;

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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult PostBruger([FromBody] Bruger bruger)
        {
            using (var PostBruger = _context)
            {
                if (PostBruger != null)
                {
                    _context.Brugers.Add(bruger);
                    _context.SaveChanges();
                    return Ok("tilfoej bruger");
                }
                else
                {
                    return NotFound("Not added");
                }

            }
            
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
