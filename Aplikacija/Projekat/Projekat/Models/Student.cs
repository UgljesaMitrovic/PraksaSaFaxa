using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekat.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Fakultet { get; set; }
        public string Smer { get; set; }
        [Display(Name = "Stepen studija")]
        public string StepenStudija { get; set; }
        public double Prosek { get; set; }
        public string Grad { get; set; }
        public IList<string> Tehnologije { get; set; }
        public IList<StudentToOglas> StudentToOglasi { get; set; }

        public IList<Prijava> Prijave { get; set; }

        public IList<Poziv> Pozivi { get; set; }
    }
}