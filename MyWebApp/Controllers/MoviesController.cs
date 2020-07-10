using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebApp.Models;
using MyWebApp.ViewModels;
using System.Data.Entity;

namespace MyWebApp.Controllers
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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {                
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            
            if(!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {                    
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }            
            
            if (movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieIndb = _context.Movies.Single(m => m.ID == movie.ID);

                movieIndb.Name = movie.Name;
                movieIndb.GenreID = movie.GenreID;
                movieIndb.ReleaseDate = movie.ReleaseDate;
                movieIndb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel(movie)
            {                
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        // GET: Movies
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int ID)
        {
            var movie = _context.Movies.Include(Movie => Movie.Genre).SingleOrDefault(Movie => Movie.ID == ID);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { ID = 10, Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer { ID = 1, Name = "Customer1"},
                new Customer { ID = 2, Name = "Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers               
            };

            return View(viewModel);
        }

        [Route("Movies/Released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }       
    }
}