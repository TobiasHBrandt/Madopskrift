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
        //public async Task<IActionResult> Details(int? id)
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

        [HttpGet("{Id}")]
        public IActionResult GetBruger(int id)
        {
            MadopskriftDbContext visBruger = _context;
            // den laver en query select på Opskrift som ville hente kolonner
            Bruger bruger = visBruger.Brugers.Select(a => new Bruger
            {
                // sætter opskrift værdier til at være lig med a parameter
                Id = a.Id,
                Brugernavn = a.Brugernavn,
                Alder = a.Alder,
                Email = a.Email
               
                // den tjekker om det indeholder en id hvis den gør ville den vælge første id
            }).Where(a => a.Id == id).FirstOrDefault();

            if (bruger == null)
            {
                return NotFound();
            }

            return Ok(bruger);
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

            // tjekker om brugeren ikke er null
            if (PostBruger != null)
            {
                // ville tiljøje og gemme brugeren hvor den returnere en ok
                PostBruger.Brugers.Add(bruger);
                PostBruger.SaveChanges();
                return Ok("tilfoej bruger");
            }

            // hvis brugeren er en null værdi ville den ikke tilføje brugeren
            else
            {
                return NotFound("Not added");
            }

        }

        [HttpPost("login", Name = "login")]

        public ActionResult Login(Bruger bruger)
        {
            // en lokal variable
            MadopskriftDbContext PostBruger = _context;

            // tjekker om brugeren ikke er null
            if (PostBruger != null)
            {
                // ville tjekke om email og password matcher
                Bruger login = PostBruger.Brugers.SingleOrDefault(a => a.Email == bruger.Email && a.Password == bruger.Password);
                // hvis login ikke matcher
                if (login == null)
                {
                    Bruger bruger2 = new Bruger();
                    return Ok(bruger2);
                }
                // hvis de matcher
                else
                {
                    return Ok(login);
                }
                

            }

            // hvis brugeren er en null værdi ville den ikke tilføje brugeren
            else
            {
                return NotFound("Not added");
            }

        }

        [HttpPut("{id}")]
        public IActionResult PutBruger(int id, Bruger bruger)
        {
            // en lokal variable
            MadopskriftDbContext putBruger = _context;

            // den tjekker om det indeholder en id hvis den gør ville den vælge første id
            Bruger existingBruger = putBruger.Brugers.Where(o => o.Id == id).FirstOrDefault();

            // tjekker om bruger ikke er null
            if (existingBruger != null)
            {
                // sætter existingOpskrift til at være lig med bruger
                existingBruger.Brugernavn = bruger.Brugernavn;
                existingBruger.Alder = bruger.Alder;
                existingBruger.Email = bruger.Email;

                // den vil gemme opdateringen og returnere en Ok
                putBruger.SaveChanges();
                return Ok();
            }
            // hvis opskrift er en null værdi ville den ikke opdatere bruger
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteBruger(int id)
        {
            // lokal variable
            MadopskriftDbContext putBruger = _context;
            // den tjekker om det indeholder en id hvis den gør ville den vælge første id
            Bruger existingBruger = putBruger.Brugers.Where(o => o.Id == id).FirstOrDefault();

            // tjekker om opskrift ikke er null
            if (existingBruger != null)
            {
                // ville slette bruger og gemme 
                putBruger.Brugers.Remove(existingBruger);
                putBruger.SaveChanges();
                // returnere en Ok
                return Ok();
            }
            // hvis bruger er en null værdi ville den ikke slette bruger
            else
            {
                return NotFound();
            }
        }

    }
}
