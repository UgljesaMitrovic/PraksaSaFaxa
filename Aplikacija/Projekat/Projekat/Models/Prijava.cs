﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class Prijava
    {
        public int PrijavaId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int FirmaId { get; set; }
        public Firma Firma { get; set; }
    }
}