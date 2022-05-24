using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    // Filter execute before a method or before all methods in this controller
    // all methods will use this if above a controller method
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUser _currentUser;
        public UserController(IUserService userService, ICurrentUser currentUser)
        {
            _userService = userService;
            _currentUser = currentUser;
        }


        // show all the movies purchased by currenly logid in user
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            // first should check whether the user is logged in
            // if the user is not loged in => redirect to login in page
            // 10:00 AM user eamil/password => sth that can be used at 10:05
            // cookie, authentication cookies that can be used across http request and check whether the user is loged in or not.
            // cookies is located in Browser

            // 10:05 he/she calls user/purchase
            // look for the authCookie and look for exp time and get the userid
            // Http Request is independent of each other, but


            // if the user is loged in => go to purchase details page
            // need userid, go to purchase table and get all movie purchased by userid
            // display as movie cards, use movie card partial view

            // var data = this.HttpContext.Request.Cookies["MovieShopAuthCookie"];
            // var isLogedIn = this.HttpContext.User.Identity.IsAuthenticated;
            // if (!isLogedIn)
            // {
            //redirect to login page
            // }
            // instead of above, use Filters in asp.net


            var userId = _currentUser.UserId;
            var movieCards = _userService.GetAllPurchasesForUser(userId);
            // need to call user service, user service should have method  getMoviePurchasedbyUser(int userid) -> List<MovieCard>
            // send it to database
            // decrypt the cookie and get the userid from the cookie and expiration time from the cookies
            // use the userid to go to database and get the movies purchased
            return View(movieCards);
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = _currentUser.UserId;
            var movieCards = _userService.GetAllFavoritesForUser(userId);
            return View(movieCards);
        }

        public async Task<IActionResult> Reviews()
        {
            var userId = _currentUser.UserId;
            return View();
        }

        public async Task<IActionResult> Buy()
        {
            var userId = _currentUser.UserId;
            return View();
        }
    }
}
