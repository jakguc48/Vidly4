using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly4.Models;

namespace Vidly4.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Models.MovieGenere> MovieGeneres { get; set; }
        public string FormType { get; set; }
    }
}