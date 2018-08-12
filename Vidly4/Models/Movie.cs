using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly4.Models
{
    public class Movie
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
        [Required]
        public MovieGenere MovieGenere { get; set; }
        [Required]
        public DateTime ReleaseDate  { get; set; }
        [Required]
        public DateTime AddDate { get; set; }
        [Required]
        public byte NumberInStock { get; set; }
    }
}