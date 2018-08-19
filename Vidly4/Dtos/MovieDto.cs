using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly4.Models;

namespace Vidly4.Dtos
{
    public class MovieDto
    {
        [Required]
        public string Name { get; set; }

        public int Id { get; set; }

        [Required]
        public int MovieGenereId { get; set; }

        public MovieGenereDto MovieGenere { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }


        public DateTime? AddDate { get; set; }

        [Required]
        public byte NumberInStock { get; set; }
    }
}