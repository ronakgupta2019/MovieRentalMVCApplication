using MovieRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieRentalMVCApplication.View_Models;
using MovieRentalMVCApplication.ViewModels;

namespace MovieRentalMVCApplication.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        public ActionResult Details(int? id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }
        public ActionResult Edit(int? id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel
            {
                Movie = movies,
                Genre = _context.Genres.ToList()
            };
            return View("New", viewModel);
        }
        public ActionResult New()
        {
            var genreTypes = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genre = genreTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.MovieName = movie.MovieName;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DateAdded = movie.DateAdded;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
        public ActionResult Delete(int id)
        {
            Movie movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}