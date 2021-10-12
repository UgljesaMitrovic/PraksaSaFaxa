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
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext(); 
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Student
        public async Task<ActionResult> ViewAll()
        {
            var vm = new StudentViewModel()
            {
                Studenti =await _context.Studenti.ToListAsync()
            }; 
            return View(vm);
        }

        public async Task<ActionResult> ViewProfile()
        {
            var currentId = User.Identity.GetUserId();
            var student = await _context.Studenti.Include(x => x.StudentToOglasi).Include(x => x.Pozivi).Where(x => x.IdUser == currentId).FirstOrDefaultAsync();
            foreach (var studentToOglas in student.StudentToOglasi)
            {
                if (studentToOglas.StudentId == student.Id)
                {
                    studentToOglas.Oglas = _context.Oglasi.Find(studentToOglas.OglasId);
                }
            }
            foreach (var poziv in student.Pozivi)
            {
                if (poziv.StudentId == student.Id)
                {
                    poziv.Firma = _context.Firme.Find(poziv.FirmaId);
                }
            }
            return View(student);
        }
        public async Task<ActionResult> EditProfile()
        {
            var currentId = User.Identity.GetUserId();
            var student =await _context.Studenti.Include(x=>x.StudentToOglasi).Include(x=>x.Pozivi).Where(x => x.IdUser == currentId).FirstOrDefaultAsync();
            return View(student);
        }
        public async Task<ActionResult> ViewProfileAsGuest(int id)
        {
            var student = await _context.Studenti.Where(x => x.Id == id).FirstOrDefaultAsync();//INCLUDE!
            return View(student);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Student studentEdit)
        {

            var student = _context.Studenti.Single(s => s.Id == studentEdit.Id);
            student.Ime = studentEdit.Ime;
            student.Prezime = studentEdit.Prezime;
            student.Fakultet = studentEdit.Fakultet;
            student.Smer = studentEdit.Smer;
            student.StepenStudija = studentEdit.StepenStudija;
            student.Prosek = studentEdit.Prosek;
            student.Grad = studentEdit.Grad;
            student.Tehnologije = studentEdit.Tehnologije;
            await _context.SaveChangesAsync();


            return RedirectToAction("ViewProfile","Student");
        }
        public async Task<ActionResult> PrihvatiStudenta(int firmaId, int studentId)
        {
            var prijava = _context.Prijave.Where(x => x.StudentId == studentId && x.FirmaId == firmaId).FirstOrDefault();
            _context.Prijave.Remove(prijava);

            _context.Pozivi.Add(new Poziv { FirmaId = firmaId, StudentId = studentId });

            await _context.SaveChangesAsync();
            return RedirectToAction("ViewProfile", "Firma");
        }
        public async Task<ActionResult> OdbijStudenta(int firmaId, int studentId)
        {
            var prijava = _context.Prijave.Where(x => x.StudentId == studentId && x.FirmaId == firmaId).FirstOrDefault();
            _context.Prijave.Remove(prijava);
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewProfile", "Firma");
        }
    }
}