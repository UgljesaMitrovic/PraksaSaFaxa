using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class Firma
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Ime { get; set; }
        public string Grad { get; set; }
        public IList<Oglas> Oglasi { get; set;}

        public IList<Prijava> Prijave { get; set; }

        public IList<Poziv> Pozivi { get; set; }
    }
}