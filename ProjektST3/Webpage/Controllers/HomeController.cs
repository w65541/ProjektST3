using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Webpage.Models;
using Webpage.ExternalDto;
using Webpage.Resolvers;
namespace Webpage.Controllers
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

        [HttpGet]
        public IActionResult Index(int id) {

                Userr = _profile.GetById(id);
                return View(Userr);

        }
        [HttpGet]
        public IActionResult UserProfile(int id)
        {

            Userr = _profile.GetById(id);
            return View(Userr);

        }
        [HttpGet]
        public IActionResult Profile(int id1, int id2,int id3) {
            ProfileData temp = new ProfileData { Profil= _profile.GetById(id2),Id= id1, IdUser= id3 };
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
