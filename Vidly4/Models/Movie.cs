﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly4.Models
{
    public class Movie
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public int Id { get; set; }

        [Display(Name = "Genere")]
        public MovieGenere MovieGenere { get; set; }

        [Display(Name = "Genere")]
        [Required]
        public int MovieGenereId { get; set; }

        

        
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate  { get; set; }

        
        public DateTime? AddDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public byte NumberInStock { get; set; }
    }
}