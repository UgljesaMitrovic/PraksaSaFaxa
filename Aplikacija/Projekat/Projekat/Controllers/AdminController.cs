using Microsoft.AspNet.Identity;
using Projekat.Migrations;
using Projekat.Models;
using Projekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> ViewAllStudente()
        {
            var vm = new StudentViewModel()
            {
                Studenti = await _context.Studenti.ToListAsync()
            };
            return View(vm);
        }
        public async Task<ActionResult> ObrisiStudenta(int id)
        {
            var student = _context.Studenti.Find(id);
            var user = _context.Users.Find(student.IdUser);
            _context.Studenti.Remove(student);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewAllStudente", "Admin");
            //return Content("evo ti ga id" + user.Id);  // ContentResult mora da bude tip akcije
        }
        public async Task<ActionResult> ViewAllFirme()
        {
            var vm = new FirmaViewModel()
            {
                Firme =await _context.Firme.ToListAsync()
            };
            return View(vm);
        }
        public async Task<ActionResult> ObrisiFirmu(int id)
        {
            var firma = _context.Firme.Find(id);
            var user = _context.Users.Find(firma.IdUser);
            _context.Firme.Remove(firma);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewAllFirme", "Admin");
            //return Content("evo ti ga id" + user.Id);  // ContentResult mora da bude tip akcije
        }
        [Route("admin/oglasi")]
        public async Task<ActionResult> ViewAllOglase(int ShowModal = 0)
        {
            var vm = new OglasViewModel()
            {
                Oglasi =await _context.Oglasi.ToListAsync()
            };


            ViewBag.ShowModal = ShowModal;
            return View(vm);
        }
        public async Task<ActionResult> ObrisiOglas(int id)
        {
            var oglas = _context.Oglasi.Find(id);
            _context.Oglasi.Remove(oglas);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewAllOglase", "Admin");
            //return Content("evo ti ga id" + user.Id);  // ContentResult mora da bude tip akcije
        }

    }
}