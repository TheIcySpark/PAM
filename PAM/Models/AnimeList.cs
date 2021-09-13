using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAM.Models
{
    public class AnimeList
    {
        public int AnimeListID { get; set; }
        public int AnimeItems { get; set; }

        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
