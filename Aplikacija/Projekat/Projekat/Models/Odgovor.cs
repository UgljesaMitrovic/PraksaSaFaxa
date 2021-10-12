using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class Odgovor
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public Student Student { get; set; }
        public Post Post { get; set; }
        public DateTime Datum { get; set; }

        public Odgovor()
        {
            this.Datum = DateTime.Now.Date;
        }
    }
}