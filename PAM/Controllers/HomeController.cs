using IMDbApiLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PAM.Data;
using PAM.Models;
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

        public IActionResult Index()
        {
            ViewBag.imgsrc = _viewBagImageController.SetViewBagImage(User);
            return View();
        }


        public async Task<IActionResult> UpdateDatabaseAsync()
        {
            var apiLib = new ApiLib("k_b1de48d1");
            var titleData = await apiLib.TitleAsync("tt1375666/Trailer");
            
            return Redirect("/");
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
