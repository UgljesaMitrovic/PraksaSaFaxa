using Projekat.Models;
using Projekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Migrations;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace Projekat.Controllers
{
    public class OglasController : Controller
    {
        private ApplicationDbContext _context;

        public OglasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("oglas/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("oglas")]
        public async Task<ActionResult> Create(Oglas oglas)
        {
            var currentId = User.Identity.GetUserId();
            var ulogovanaFirma = _context.Firme.Where(x => x.IdUser == currentId).FirstOrDefault();
            oglas.Firma = ulogovanaFirma;
            _context.Oglasi.Add(oglas);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewAll", "Oglas", new { ShowModal = 1 });
        }

        [Route("oglasi")]
        public async Task<ActionResult> ViewAll(int ShowModal = 0)
        {
            bool firma = false;
            if (User.IsInRole("Firma"))
            {
                firma = true;
            }

            var vm = new OglasViewModel()
            {
                Oglasi = await _context.Oglasi.Include(x => x.Firma).ToListAsync(),
                UlogovanaFirma = firma
            };


            ViewBag.ShowModal = ShowModal;
            return View(vm);
        }
        [Route("oglasiAsStudent")]
        public async Task<ActionResult> ViewAllAsStudent(int ShowModal = 0)
        {
            bool firma = false;
            if (User.IsInRole("Firma"))
            {
                firma = true;
            }
            //TREBA  N M VEZA 
            var vm = new OglasViewModel()
            {
                Oglasi = await _context.Oglasi.Include(x => x.Firma).Include(x=>x.StudentToOglasi).ToListAsync(),
                UlogovanaFirma = firma
            };
            foreach(var oglas in vm.Oglasi) 
            {
                foreach(var studentToOglas in oglas.StudentToOglasi)
                {
                    studentToOglas.Student = _context.Studenti.Find(studentToOglas.StudentId);
                    //Ovo sam uradio jer se to ne podrazumeva a treba mi idUser kad proveravam da li treba da postoji opcija sacuvaj za oglas
                }
            }

            ViewBag.ShowModal = ShowModal;
            return View(vm);
        }

        [Route("oglas/{id}")]
        public ActionResult ViewSingle(int id)
        {
            var oglas = _context.Oglasi.Include(x=> x.Firma).Single(m => m.Id == id);
            return View(oglas);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var oglas = _context.Oglasi.Find(id);
            _context.Oglasi.Remove(oglas);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewProfile","Firma");
        }
        [Route("otvoren/{id}")]

        public async Task<ActionResult> OtvoriDetalje(int id)
        {
            var oglas = _context.Oglasi.Find(id);
            oglas.Potvrdjen = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewAll", "Oglas");
        }
        [Route("zatvoren/{id}")]

        public async Task<ActionResult> ZatvoriDetalje(int id)
        {
            var oglas = _context.Oglasi.Find(id);
            oglas.Potvrdjen = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewAllAsStudent", "Oglas");
        }
        public async Task<ActionResult> SacuvajOglas(int id)
        {
            var idUser = User.Identity.GetUserId();
            var student = _context.Studenti.Where(x => x.IdUser == idUser).FirstOrDefault();
            var oglas = _context.Oglasi.Find(id);
            _context.StudentToOglasi.Add(new StudentToOglas { OglasId = id, StudentId = student.Id });
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewAllAsStudent", "Oglas");
        }
        [Route("oglas/brisi/{oglasId}/{studentId}")]
        public async Task<ActionResult> NeCuvajViseOglas(int oglasId,int studentId)
        {
            var studentToOglas = _context.StudentToOglasi.Where(x => x.StudentId == studentId && x.OglasId == oglasId).FirstOrDefault();
            _context.StudentToOglasi.Remove(studentToOglas);
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewProfile", "Student");
        }
    }
}
