using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAM.Models
{
    public class IMDBItem
    {
        public int IMDBItemID { get; set; }
        public List<IMDBActor> ActorsList { get; set; }
        public string Awards { get; set; }
        public List<IMDBCompany> Companys { get; set; }
        public string ContentRating { get; set; }
        public List<IMDBDirector> DirectorsList { get; set; }
        public List<IMDBGenre> GenresList { get; set; }
        public String IMDBRating { get; set; }
        public string IMDBID { get; set; }
        public string ImageLink { get; set; }
        public string MetacriticRating { get; set; }
        public string Plot { get; set; }
        public string Runtime { get; set; }
        public string Title { get; set; }
        public string TrailerLink { get; set; }
        public string Type { get; set; }
        public List<IMDBWriter> WritersList { get; set; }
        public string Year { get; set; }

    }
}
