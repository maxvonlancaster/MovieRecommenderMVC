using Microsoft.AspNetCore.Mvc;
using MovieRecommenderMVC.BLL.Models;
using MovieRecommenderMVC.BLL.Services.Interfaces;
using MovieRecommenderMVC.DAL.Entities;

namespace MovieRecommenderMVC.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public MovieController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        public IActionResult Movie()
        {
            return View();
        }

        [HttpGet]
        [Route("getAllMovies")]
        public ActionResult GetAllMovies()
        {
            var movies = _movieService.GetAll(null);
            return Json(movies);
        }

        [HttpPost]
        [Route("addMovie")]
        public void AddMovie([FromBody]MovieModel postdata)
        {
            var movie = new Movie()
            {
                Name = postdata.MovieName,
                Ganre = _genreService.GetGenreByName(postdata.MovieGanre)
            };
            _movieService.Add(movie);
        }

        [HttpPost]
        [Route("updateMovie")]
        public void UpdateMovie([FromBody]MovieModel postdata)
        {
            var movie = new Movie()
            {
                MovieId = postdata.MovieId ?? 0,
                Name = postdata.MovieName,
                Ganre = _genreService.GetGenreByName(postdata.MovieGanre)
            };
            _movieService.Update(movie);
        }

        [HttpPost]
        [Route("deleteMovie")]
        public void DeleteMovie([FromBody]MovieModel postdata)
        {
            _movieService.DeleteById(postdata.MovieId ?? 0);
        }

        [HttpGet]
        [Route("getGenres")]
        public ActionResult GetGenres()
        {
            var genres = _genreService.GetAll(null);
            return Json(genres);
        }
    }
}