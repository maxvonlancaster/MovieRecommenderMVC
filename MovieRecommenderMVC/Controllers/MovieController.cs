using Microsoft.AspNetCore.Mvc;
using MovieRecommenderMVC.BLL.Services.Interfaces;

namespace MovieRecommenderMVC.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
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


    }
}