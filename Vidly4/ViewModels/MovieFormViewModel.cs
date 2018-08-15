using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly4.Models;

namespace Vidly4.ViewModels
{
    public class MovieFormViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Genere")]
        public int? MovieGenereId { get; set; }



        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }


        [Required]
        [MovieNumberInStockReq]
        [Display(Name = "Number in stock")]
        public byte? NumberInStock { get; set; } 



        public IEnumerable<Models.MovieGenere> MovieGeneres { get; set; }
        public string FormType { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Name = movie.Name;
            Id = movie.Id;
            MovieGenereId = movie.MovieGenereId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }
    }
}