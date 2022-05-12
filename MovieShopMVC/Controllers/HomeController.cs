using ApplicationCore.Contracts.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            // MovieService implements interface IMovieService, so no error
            //_movieService = new MovieService();
            // newing up, want code to rely on abstractions instead of concreate types
            _movieService = movieService;
        }

        //Action Method
        //https://localhost:0/home/index
        [HttpGet]
        public IActionResult Index()
        {
            // this is hardcoding, tightly coupled , we want loosely coupled
            //var movieService = new MovieService();
            //var movieCards = movieService.GetTop30GrossingMovies();

            // newing up
            // we can have some higher level framework to create instances
            var movieCards = _movieService.GetTop30GrossingMovies();

            // passing the data from Controller action method to View
            //the index view is return because the method has the same name as the view
            return View(movieCards);
            //Views in MVC is called RAzor with cshtml extension 
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        //https://localhost:0/home/topratedmovies
        public IActionResult TopRatedMovies()
        {
            //default view can be overloaded by adding "Privacy"
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}