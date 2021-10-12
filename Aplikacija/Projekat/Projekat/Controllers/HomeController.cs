using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentiViewAll()
        {
            if (User.IsInRole("Student") || User.IsInRole("Firma"))
                return RedirectToAction("ViewAll", "Student");
            // Za admina treba isti takav viewAll samo sa opcijom za brisanje
            if (User.IsInRole("Admin"))
                return RedirectToAction("ViewAllStudente", "Admin");
            else
                return RedirectToAction("ViewAll", "Student");
        }

        public ActionResult FirmeViewAll()
        {
            if (User.IsInRole("Firma"))
                return RedirectToAction("ViewAll", "Firma");
            // Za studenta treba da ima opcija za prijavljivanje u odredjenoj firmi
            if (User.IsInRole("Student"))
                return RedirectToAction("ViewAllAsStudent", "Firma");
            // Za admina treba isti takav viewAll samo sa opcijom za brisanje
            if (User.IsInRole("Admin"))
                return RedirectToAction("ViewAllFirme", "Admin");
            else
                return RedirectToAction("ViewAll", "Firma");
        }
        public ActionResult OglasiViewAll()
        {
                //Ovde treba svako drugaciji view da dobije
                //Firma i Anoniman posetilac obican 
                //Student sa opcijom da se prijavi na neki od oglasa
                // Za admina treba isti takav viewAll samo sa opcijom za brisanje
            if (User.IsInRole("Firma"))
                return RedirectToAction("ViewAll", "Oglas");
            if (User.IsInRole("Student"))
                return RedirectToAction("ViewAllAsStudent", "Oglas");
            // Za admina treba isti takav viewAll samo sa opcijom za brisanje
            if (User.IsInRole("Admin"))
                return RedirectToAction("ViewAllOglase", "Admin");
            else
                return RedirectToAction("ViewAll", "Oglas");
        }
        public ActionResult PostoviViewAll()
        {
            if (User.IsInRole("Student"))
                return RedirectToAction("ViewAll", "Forum");
            if (User.IsInRole("Admin"))
                return RedirectToAction("ViewAll", "Forum");
            else
                return Content("Samo prijavljeni studenti mogu pristupiti forumu!");
        }
        public ActionResult Profile()
        {
            // Za admina Ovo ni ne treba da se pojavi kao link na home-u
            if (User.IsInRole("Student"))
                return RedirectToAction("ViewProfile", "Student");
            if (User.IsInRole("Firma"))
                return RedirectToAction("ViewProfile", "Firma");
            else
                return Content("Morate se registrovati kao student ili firma da bi imali svoj profil");
        }
    }
}