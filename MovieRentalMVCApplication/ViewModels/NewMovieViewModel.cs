﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalMVCApplication.Models;

namespace MovieRentalMVCApplication.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }
    }
}