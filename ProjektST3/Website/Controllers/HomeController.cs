using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;
using Website.ExternalDto;
using Website.Resolvers;
namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProfileResolver _profile;
       
        private readonly ILogger<HomeController> _logger;
        public int UserId;
        public ProfileDto Userr;

        public HomeController(ILogger<HomeController> logger, ProfileResolver profile)
        {
            _logger = logger;
            _profile = profile;
        }
        public IActionResult Login()
        {
            Userr = null;
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(Userr);
        }
        public IActionResult UserProfile() 
        {
            return View(Userr);
        }
        public IActionResult External()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register(string login,string haslo,string email)
        {

            return View(new ExternalUserDto { Login=login,Haslo=haslo,Email=email});
        }
        [HttpGet]
        public IActionResult Index(int id) {

                Userr = _profile.GetByIdAsync(id).Result;
                return View(Userr);

        }
        [HttpGet]
        public IActionResult UserProfile(int id)
        {

            Userr = _profile.GetByIdAsync(id).Result;
            return View(Userr);

        }
        [HttpGet]
        public IActionResult Profile(int id1, int id2,int id3) {
            ProfileData temp = new ProfileData { Profil= _profile.GetByIdAsync(id2).Result,Id= id1, IdUser= id3 };
            return View(temp);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
