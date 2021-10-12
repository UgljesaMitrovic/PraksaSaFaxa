using Microsoft.AspNet.Identity;
using Projekat.Migrations;
using Projekat.Models;
using Projekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class FirmaController : Controller
    {
        // GET: Firma

        private ApplicationDbContext _context;

        public FirmaController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public async Task<ActionResult> ViewAll()
        {
            var vm = new FirmaViewModel()
            {
                Firme =await _context.Firme.ToListAsync()
            };
            return View(vm);
        }
        public async Task<ActionResult> ViewAllAsStudent()
        {
            var vm = new FirmaViewModel()
            {
                Firme = await _context.Firme.Include(x => x.Prijave).ToListAsync()//NE ZABORAVLJAJ INCLUDE!
            };
            foreach (var firma in vm.Firme)
            {
                foreach (var prijava in firma.Prijave)
                {
                    prijava.Student = _context.Studenti.Find(prijava.StudentId);
                    //Ovo sam uradio jer se to ne podrazumeva a treba mi idUser kad proveravam da li treba da postoji opcija prijavi se za firmu
                }
            }
            return View(vm);
        }
        public async Task<ActionResult> ViewProfile()
        {
            var currentId = User.Identity.GetUserId();
            var firma = await _context.Firme.Include(x=>x.Oglasi).Include(x=>x.Prijave).Where(x => x.IdUser == currentId).FirstOrDefaultAsync();//INCLUDE!
            foreach (var prijava in firma.Prijave)
            {
                if (prijava.FirmaId == firma.Id)
                {
                    prijava.Student = _context.Studenti.Find(prijava.StudentId);
                }
            }

            return View(firma);
        }
        public async Task<ActionResult> EditOglas()
        {
            var currentId = User.Identity.GetUserId();
            var firma = await _context.Firme.Include(x => x.Oglasi).Include(x => x.Prijave).Where(x => x.IdUser == currentId).FirstOrDefaultAsync();//INCLUDE!
            foreach (var prijava in firma.Prijave)
            {
                if (prijava.FirmaId == firma.Id)
                {
                    prijava.Student = _context.Studenti.Find(prijava.StudentId);
                }
            }

            return View(firma);
        }
        public async Task<ActionResult> ViewProfileAsGuest(int id)
        {
            var firma = await _context.Firme.Include(x => x.Oglasi).Where(x => x.Id == id).FirstOrDefaultAsync();//INCLUDE!
            return View(firma);
        }
        public async Task<ActionResult> Edit(Firma firmaEdit)
        {

            //var firma = _context.Firme.Single(s => s.Id == firmaEdit.Id);
            //firma.Ime = firmaEdit.Ime;
            //firma.Grad = firmaEdit.Grad;
            var oglasi = _context.Oglasi.Where(x => x.Firma.Id == firmaEdit.Id).ToList();
            foreach (var oglas in oglasi.Select((value, i) => new { i, value }))
            {
                oglas.value.Naslov = firmaEdit.Oglasi[oglas.i].Naslov;
                oglas.value.Tehnologije = firmaEdit.Oglasi[oglas.i].Tehnologije;
                oglas.value.OpisOglasa = firmaEdit.Oglasi[oglas.i].OpisOglasa;
            }

            await _context.SaveChangesAsync();


            return RedirectToAction("ViewProfile", "Firma");
        }
        public async Task<ActionResult> PrijaviSeUFirmu(int id)
        {
            var idUser = User.Identity.GetUserId();
            var student = _context.Studenti.Where(x => x.IdUser == idUser).FirstOrDefault();
            var firma = _context.Firme.Find(id);
            _context.Prijave.Add(new Prijava { StudentId = student.Id, FirmaId = id});
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewAllAsStudent", "Firma");
        }
        public async Task<ActionResult> IzbrisiPoziv(int firmaId, int studentId)
        {
            var poziv = _context.Pozivi.Where(x => x.StudentId == studentId && x.FirmaId == firmaId).FirstOrDefault();
            _context.Pozivi.Remove(poziv);
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewProfile", "Student");
        }
    }
}