using IMDbApiLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PAM.Data;
using PAM.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

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

        public List<string> GetIMDBGenresLinks()
        {
            List<string> IMDBGenresLinks = new List<string>();
            IMDBGenresLinks.AddRange(new string[] {
                "https://www.imdb.com/search/title/?title_type=feature&num_votes=10000,&genres=action,mystery&languages=en&explore=genres&ref_=adv_prv" });
            return IMDBGenresLinks;
        }

        public async Task UpdateDatabaseFromIMDBGenreLinkAsync(string genreLink)
        {
            string nextGenreLink = genreLink;

            while (nextGenreLink != "")
            {
                HtmlWeb htmlWeb = new HtmlWeb();
                HtmlDocument htmlDocument = htmlWeb.Load(nextGenreLink);
                foreach(var nodeListenItemHeader in htmlDocument.DocumentNode.CssSelect(".lister-item-header"))
                {
                    var IMDBIdLink = nodeListenItemHeader.CssSelect("a").First().GetAttributeValue("href");
                    string IMDBId = IMDBIdLink.Split('/')[2];

                    if (_context.IMDBItem
                        .Where(IMDBItem => IMDBItem.IMDBID == IMDBId)
                        .Select(IMDBItem => IMDBItem.IMDBID)
                        .FirstOrDefault() != null)
                    {
                        continue;
                    }
                    var apiLib = new ApiLib("k_b1de48d1");

                    var IMDBData = await apiLib.TitleAsync(IMDBId + "/Trailer");


                    List<IMDBActor> actorsList = new List<IMDBActor>();
                    foreach (var actor in IMDBData.ActorList)
                    {
                        actorsList.Add(new IMDBActor
                        {
                            ActorName = actor.Name,
                            CharacterName = actor.AsCharacter,
                            ImageLink = actor.Image
                        });
                    }

                    List<IMDBCompany> companysList = new List<IMDBCompany>();
                    foreach (var company in IMDBData.CompanyList)
                    {
                        companysList.Add(new IMDBCompany
                        {
                            CompanyName = company.Name
                        });
                    }

                    List<IMDBDirector> directorsList = new List<IMDBDirector>();
                    foreach (var director in IMDBData.DirectorList)
                    {
                        directorsList.Add(new IMDBDirector
                        {
                            DirectorName = director.Name
                        });
                    }

                    List<IMDBGenre> genresList = new List<IMDBGenre>();
                    foreach (var genre in IMDBData.GenreList)
                    {
                        genresList.Add(new IMDBGenre
                        {
                            Genre = genre.Value
                        });
                    }

                    List<IMDBWriter> writersList = new List<IMDBWriter>();
                    foreach (var writer in IMDBData.WriterList)
                    {
                        writersList.Add(new IMDBWriter
                        {
                            WriterName = writer.Name
                        });
                    }

                    _context.IMDBItem.Add(new IMDBItem
                    {
                        ActorsList = actorsList,
                        Awards = IMDBData.Awards,
                        CompanysList = companysList,
                        ContentRating = IMDBData.ContentRating,
                        DirectorsList = directorsList,
                        GenresList = genresList,
                        ImageLink = IMDBData.Image,
                        IMDBID = IMDBData.Id,
                        IMDBRating = IMDBData.IMDbRating,
                        MetacriticRating = IMDBData.MetacriticRating,
                        Plot = IMDBData.Plot,
                        Runtime = IMDBData.RuntimeStr,
                        Title = IMDBData.Title,
                        TrailerLink = IMDBData.Trailer.LinkEmbed,
                        Type = IMDBData.Type,
                        WritersList = writersList,
                        Year = IMDBData.Year
                    });

                    await _context.SaveChangesAsync();
                }

                if (htmlDocument.DocumentNode.CssSelect(".next-page").Count() != 0)
                {
                    nextGenreLink = "https://www.imdb.com" + htmlDocument.DocumentNode.CssSelect(".next-page").First().GetAttributeValue("href");
                }
                else
                {
                    nextGenreLink = "";
                }
            }
        }

        public async Task<IActionResult> UpdateDatabaseAsync()
        {
            var apiLib = new ApiLib("k_b1de48d1");
            List<string> IMDBGenresLinks = GetIMDBGenresLinks();
            foreach(string genreLink in IMDBGenresLinks)
            {
                await UpdateDatabaseFromIMDBGenreLinkAsync(genreLink);
            }
            //var IMDBData = await apiLib.TitleAsync("tt1375666/Trailer");

            //if(_context.IMDBItem
            //    .Where(IMDBItem => IMDBItem.IMDBID == IMDBData.Id)
            //    .Select(IMDBItem => IMDBItem.IMDBID)
            //    .FirstOrDefault() != null)
            //{
            //    return Redirect("/");
            //}

            //List<IMDBActor> actorsList = new List<IMDBActor>();
            //foreach(var actor in IMDBData.ActorList)
            //{
            //    actorsList.Add(new IMDBActor
            //    {
            //        ActorName = actor.Name,
            //        CharacterName = actor.AsCharacter,
            //        ImageLink = actor.Image
            //    });
            //}

            //List<IMDBCompany> companysList = new List<IMDBCompany>();
            //foreach(var company in IMDBData.CompanyList)
            //{
            //    companysList.Add(new IMDBCompany
            //    {
            //        CompanyName = company.Name
            //    });
            //}

            //List<IMDBDirector> directorsList = new List<IMDBDirector>();
            //foreach(var director in IMDBData.DirectorList)
            //{
            //    directorsList.Add(new IMDBDirector
            //    {
            //        DirectorName = director.Name
            //    });
            //}

            //List<IMDBGenre> genresList = new List<IMDBGenre>();
            //foreach(var genre in IMDBData.GenreList)
            //{
            //    genresList.Add(new IMDBGenre
            //    {
            //        Genre = genre.Value
            //    });
            //}

            //List<IMDBWriter> writersList = new List<IMDBWriter>();
            //foreach(var writer in IMDBData.WriterList)
            //{
            //    writersList.Add(new IMDBWriter
            //    {
            //        WriterName = writer.Name
            //    });
            //}

            //_context.IMDBItem.Add(new IMDBItem
            //{
            //    ActorsList = actorsList,
            //    Awards = IMDBData.Awards,
            //    CompanysList = companysList,
            //    ContentRating = IMDBData.ContentRating,
            //    DirectorsList = directorsList,
            //    GenresList = genresList,
            //    ImageLink = IMDBData.Image,
            //    IMDBID = IMDBData.Id,
            //    IMDBRating = IMDBData.IMDbRating,
            //    MetacriticRating = IMDBData.MetacriticRating,
            //    Plot = IMDBData.Plot,
            //    Runtime = IMDBData.RuntimeStr,
            //    Title = IMDBData.Title,
            //    TrailerLink = IMDBData.Trailer.LinkEmbed,
            //    Type = IMDBData.Type,
            //    WritersList = writersList,
            //    Year = IMDBData.Year
            //});

            //await _context.SaveChangesAsync();

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
