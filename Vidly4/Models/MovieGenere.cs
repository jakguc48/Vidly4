using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly4.Models
{
    public class MovieGenere
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string GenereName { get; set; }
    }
}