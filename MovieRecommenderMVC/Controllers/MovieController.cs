using Microsoft.AspNetCore.Mvc;
using MovieRecommenderMVC.BLL.Models;
using MovieRecommenderMVC.BLL.Services.Interfaces;
using MovieRecommenderMVC.DAL.Entities;
using MovieRecommenderMVC.DAL.Models;
using System.Security.Claims;

namespace MovieRecommenderMVC.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movies = _movieService.GetAll(null, userId);
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

        [HttpPost]
        [Route("getPagedMovies")]
        public ActionResult GetPagedMovies([FromBody]PagingModel pagingModel)
        {
            Logger.Info("Got movies");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movies = _movieService.GetPaginatedMovies(pagingModel, userId);
            return Json(movies);
        }
    }
}