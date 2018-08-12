using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly4.Models;
using Vidly4.ViewModels;

namespace Vidly4.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        [Route("Movies")]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.MovieGenere).ToList();
            return View(movies);
        }

        [Route("Movies/Details/{numerek:regex(\\d)}")]
        public ActionResult Details(int numerek)
        {
            var movies = _context.Movies.Include(m => m.MovieGenere).SingleOrDefault(m => m.Id == numerek);
            return View(movies);
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