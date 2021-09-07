using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAM.Models
{
    public class AnimeList
    {
        public int AnimeListID { get; set; }
        public List<AnimeItem> AnimeItemsList { get; set; }
    }
}
