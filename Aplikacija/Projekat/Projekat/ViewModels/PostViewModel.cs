﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class PostViewModel
    {
        public IList<Post> Postovi { get; set; }
    }
}