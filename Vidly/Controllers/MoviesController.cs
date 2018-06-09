using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
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
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(c => c.Genre).ToList();

            //return View(movies);
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            else
                return View("ReadOnlyList");
            
        }

        public ActionResult Details(int id)
        {
         
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if(movie != null){

                return View(movie);
            }else
            {
                return HttpNotFound();
            }
            
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            ViewBag.Title = "New Movie";
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genres
            };

            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {


            if (!ModelState.IsValid)
                {
                    var viewModel = new MovieFormViewModel
                    {
                        Movie = movie,
                        Genre = _context.Genres.ToList()
                    };

                    return View("MovieForm", viewModel);
                }
         

            if(movie.Id == 0)
            {
                var genre = _context.Genres.Single(g => g.Id == movie.GenreId);
                movie.Genre = genre;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException )
            {

                throw;
            }

            return RedirectToAction("Index","Movies");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            else
            {
                ViewBag.Title = "Edit Movie";

                var viewModel = new MovieFormViewModel
                {
                    Movie = _context.Movies.Single(m => m.Id == id),
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
        }
    }
}