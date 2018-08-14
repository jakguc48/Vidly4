using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly4.Models
{
    public class Test
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public int Id { get; set; }

        [Display(Name = "Genere")]
        public MovieGenere MovieGenere { get; set; }


        public int MovieGenereId { get; set; }


        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime AddDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public byte NumberInStock { get; set; }
    }
}