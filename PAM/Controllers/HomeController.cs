using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PAM.Data;
using PAM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PAM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly PAMContext _context;

        public HomeController(ILogger<HomeController> logger, PAMContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void SetViewBagImage()
        {
            if (User.Identity.IsAuthenticated)
            {
                string googleId = User.Claims
                    .Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                    .Select(c => c.Value)
                    .FirstOrDefault();
                var user = _context.User.FirstOrDefault(m => m.GoogleUserID == googleId);
                if (user.Photo == null) return;
                var base64 = Convert.ToBase64String(user.Photo);
                var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
                ViewBag.imgsrc = imgsrc;
            }
        }

        public IActionResult Index()
        {
            SetViewBagImage();
            return View();
        }

        public IActionResult Peliculas()
        {
            SetViewBagImage();
            return View();
        }

        public IActionResult Anime()
        {
            SetViewBagImage();
            return View();
        }

        public IActionResult Videojuegos()
        {
            SetViewBagImage();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
