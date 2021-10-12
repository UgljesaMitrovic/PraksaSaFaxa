using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projekat.Models
{
    public class Oglas
    {
        public int Id { get; set; }

        public Firma Firma { get; set; }

        public DateTime DatumPostavljanja { get; set; }

        public string Naslov { get; set; }

        [Display(Name = "Opis oglasa")]
        [DataType(DataType.MultilineText)]
        public string OpisOglasa { get; set; }

        public string Tehnologije { get; set; }
        public bool Potvrdjen { get; set; }

        public IList<StudentToOglas> StudentToOglasi { get; set; }



        public Oglas()
        {
            this.Potvrdjen = false;
            this.DatumPostavljanja = DateTime.Now;

        }

    }
}