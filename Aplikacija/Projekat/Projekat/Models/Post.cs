using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Projekat.Models
{
    public class Post
    {
        public int Id { get; set;}
        [Display(Name = "Tema:")]
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }
        public IList<Odgovor> Odgovori { get; set; }
        public Post()
        {
            this.Datum = DateTime.Now;
        }
    }

}