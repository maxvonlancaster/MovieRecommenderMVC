using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRecommenderMVC.BLL.Models;
using MovieRecommenderMVC.BLL.Services.Interfaces;

namespace MovieRecommenderMVC.Controllers
{
    [Route("api/[controller]")]
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public RatingController(IRatingService ratingService, 
            IMovieService movieService, 
            IUserService userService)
        {
            _ratingService = ratingService;
            _movieService = movieService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        //AddRating, GetRating, UpdateRating

        [HttpPost]
        [Route("addRating")]
        public void AddRating([FromBody]RatingModel ratingModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ratingModel.UserId = userId;
            _ratingService.Add(ratingModel);
        }

        [HttpGet]
        [Route("getRating")]
        public ActionResult GetRating([FromBody]RatingModel ratingModel)
        {
            var returnModel = _ratingService.Get(ratingModel.Id);
            return Json(returnModel);
        }

        [HttpPost]
        [Route("updateRating")]
        public void UpdateRating([FromBody]RatingModel ratingModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ratingModel.UserId = userId;
            _ratingService.Update(ratingModel);
        }

    }
}