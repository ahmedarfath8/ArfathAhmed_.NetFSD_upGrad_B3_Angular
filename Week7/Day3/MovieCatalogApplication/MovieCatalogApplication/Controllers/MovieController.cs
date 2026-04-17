using Microsoft.AspNetCore.Mvc;
using MovieCatalogApplication.Models;

namespace MovieCatalogApplication.Controllers
{
    public class MovieController : Controller
    {
        public static List<Movie> movielist = new List<Movie>()
        {
            new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseDate = new DateTime(2010, 7, 16), Price = 499.99m, Rating = "PG-13" },
            new Movie { Id = 2, Title = "The Dark Knight", Genre = "Action", ReleaseDate = new DateTime(2008, 7, 18), Price = 399.50m, Rating = "PG-13" },
            new Movie { Id = 3, Title = "Interstellar", Genre = "Adventure", ReleaseDate = new DateTime(2014, 11, 7), Price = 599.00m, Rating = "PG-13" },
            new Movie { Id = 4, Title = "Avengers: Endgame", Genre = "Superhero", ReleaseDate = new DateTime(2019, 4, 26), Price = 699.99m, Rating = "PG-13" },
            new Movie { Id = 5, Title = "Joker", Genre = "Drama", ReleaseDate = new DateTime(2019, 10, 4), Price = 349.75m, Rating = "R" },
            new Movie { Id = 6, Title = "Titanic", Genre = "Romance", ReleaseDate = new DateTime(1997, 12, 19), Price = 299.99m, Rating = "PG-13" }
        };
        public IActionResult Index()
        {
            return View(movielist);
        }
        [HttpGet]public IActionResult Create()
        {
            return View();
        }
        [HttpPost]public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movielist.Add(movie);
                return RedirectToAction("Index");
            }
            ViewBag.message = "please enter the fields..";
            return View();
        }
        [HttpGet]public IActionResult Update(int id)
        {
            var movie = movielist.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }
        [HttpPost]public IActionResult Update(Movie movie)
        {
            var existingMovie = movielist.FirstOrDefault(m => m.Id == movie.Id);

            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Genre = movie.Genre;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.Price = movie.Price;
                existingMovie.Rating = movie.Rating;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]public IActionResult Delete(int id)
        {
            var movie = movielist.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }
        [HttpPost]public IActionResult Delete(Movie movie)
        {
            var del = movielist.FirstOrDefault(x => x.Id == movie.Id);
            if (movie != null) {
                movielist.Remove(del);
            }
            return RedirectToAction("Index");
        }
    }
}
