using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class StudentToOglas
    {
        public int StudentToOglasId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int OglasId { get; set; }
        public Oglas Oglas { get; set; }
    }
}