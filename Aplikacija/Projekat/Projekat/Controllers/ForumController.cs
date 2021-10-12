using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Migrations;
using Projekat.Models;
using Projekat.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;


namespace Projekat.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDbContext _context;


        public ForumController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Route("posts")]
        public ActionResult ViewAll()
        {
            var vm = new PostViewModel()
            {
                Postovi = _context.Postovi.ToList()
            };
            return View(vm);
        }

        [Route("post/{id}")]
        public ActionResult ViewSingle(int id, int ShowModal= 0)
        {
            var post = _context.Postovi.Include(p => p.Odgovori.Select(o=> o.Student)).Single(m => m.Id == id);
            ViewBag.ShowModal = ShowModal;
            return View(post);
        }
        [HttpPost]
        public ActionResult CreateOdgovor(Odgovor odgovor, string postId)
        {
            
            int id = Int32.Parse(postId);
            var post = _context.Postovi.Include(p => p.Odgovori.Select(o => o.Student)).Single(m => m.Id == id);
            var studentId = User.Identity.GetUserId();
            var student = _context.Studenti.Single(x => x.IdUser == studentId);
            odgovor.Student = student;
            odgovor.Post = post;
            _context.Odgovori.Add(odgovor);
            _context.SaveChanges();

            return RedirectToAction("ViewSingle", "Forum", new { @id = post.Id, ShowModal = 1 });
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult CreatePost(Post post)
        {
            _context.Postovi.Add(post);
            _context.SaveChanges();
            
            return RedirectToAction("ViewAll", "Forum");
        }
    }
}