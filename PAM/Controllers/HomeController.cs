using IMDbApiLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PAM.Data;
using PAM.Models;
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
        private readonly ViewBagImageController _viewBagImageController;

        public HomeController(ILogger<HomeController> logger, PAMContext context)
        {
            _logger = logger;
            _context = context;
            _viewBagImageController = new ViewBagImageController(_context);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);

            var user = _context.User.Where(id => id.UserID == 1).FirstOrDefault();
            var u = user.AnimeLists;
            AnimeList animeList = (new AnimeList
            {
                AnimeItems = 10,
                UserID = 1
            });
            var f = _context.Add(animeList);
            _context.SaveChanges();

            ICollection<AnimeList> theAnimeList = new List<AnimeList>();
            theAnimeList.Add(animeList);
            theAnimeList.Add(animeList);
            theAnimeList.Add(animeList);
            theAnimeList.Add(animeList);
            user.AnimeLists = theAnimeList;
            user.UserName = "xdfasdf";
            var i = await _context.SaveChangesAsync();
            return View();
        }

        public IActionResult Peliculas()
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            return View();
        }

        public IActionResult Anime()
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            return View();
        }

        public IActionResult Videojuegos()
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
