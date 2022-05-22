using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //showing the empty page
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        // when user clicks on Submit/Register Button
        // need to create another model about user registration
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            // check if the model is valid
            if (!ModelState.IsValid)
            {
                return View();
            }

            //call the account service, user repository => save the info in user table
            try 
            {
                var user = await _accountService.RegisterUser(model);
            }
            catch (ConflictException) 
            {
                throw;
                //logging the exception later to text /json file
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            // Model Binding
            try
            {
               var user = await _accountService.LoginUser(model.Email, model.Password);
                // create something so that auth cookie (10 mins, 20 mins, 1hr, 2hr...)
                // http 10:00 AM => email/pw
                // http 10:05 AM => user/purchases
                // Cookie based authentication
                // http 1:00 PM => User/Purchase, redirect to the login page

                // Create a cookie, userid, email => encryped, expiration time
                // each and every time you make an http request the cookies are sent to server in http
                // 10:00 login in => auth Cookie
                // 10:05 he/she calls user/purchases => look for the auth Cookie and look for exp time and get the userid
                // valide for 30 minutes
                // Cookie based authentication

                // claims => things the represents you like driving license (FirstName, LastName,DOB)
                // Licence => for entering some special buiding
                // likewise, claim called Admin Role to enter Admin Pages

                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.DateOfBirth, user.DaetOfBirth.ToShortDateString()),
                        new Claim("Language", "English")
                    };

                // Identity (will have those claims, what kind of authentication will use to store all claims inside the cookie)
                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                // create cookie with above claims (with options defined in Programms.cs about this cookie authenticationSchema
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // ASP.NET how long the cookie is gonna be valid
                // what the name of cookie that you want to create

                //redirect to home page
                return LocalRedirect("~/");
            }
            catch (Exception)
            {
                return View();
                throw;
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Profile()
        {
            return View();
        }

    }
}
