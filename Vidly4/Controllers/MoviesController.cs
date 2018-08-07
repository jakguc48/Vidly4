using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly4.Models;
using Vidly4.ViewModels;

namespace Vidly4.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Route("Movies")]
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        [Route("Movies/Details/{numerek:regex(\\d)}")]
        public ActionResult Details(int numerek)
        {

            return View();
        }

        private IEnumerable<Movie> GetMovies()
        {
            List < Movie > a =new List<Movie> 
            {
                new Movie {Id = 1, Name = "Shrek!"},
                new Movie {Id = 3, Name = "Shrek 2"},
                new Movie {Id = 4, Name = "Shrek 3"},
                new Movie {Id = 6, Name = "Wiy"},
                new Movie {Id = 7, Name = "Star Trek: Generations"}

            };

            return a;

        }

        [Route("Movies/Random")]
        public ActionResult Random()
        {
            var Movie_var = new Movie {Id = 1, Name = "Shrek!"};

            var CustomersList = new List<Customer>
            {
                new Customer {Id = 1, Name = "Piotr"},
                new Customer {Id = 2, Name = "Łotr"}
            };

            var viewModel = new RandomMoviesViewModel
            {
                Movie = Movie_var,
                Customers = CustomersList
            };

            return View(viewModel);
        }
    }
}