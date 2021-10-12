using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    public class OglasViewModel
    {
        public IList<Oglas> Oglasi { get; set; }
        public bool UlogovanaFirma { get; set; } 

    }
}