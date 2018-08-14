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


        [Route("Movies/New")]
        public ActionResult New()
        {
            var movieGeneres = _context.MovieGeneres.ToList();
            var viewModel = new MovieFormViewModel
            {
                MovieGeneres = movieGeneres,
                FormType = "New Movie"
            };
            return View("MovieForm", viewModel);
        }

        [Route("Movies/Edit/{id:regex(\\d)}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                MovieGeneres = _context.MovieGeneres.ToList(),
                FormType = "Edit Movie"
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
                //movie.ReleaseDate = DateTime.Now;
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.MovieGenereId = movie.MovieGenereId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }



    }
}