using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAM.Models
{
    public class AnimeItem
    {
        public enum AnimeType
        {
            Serie,
            Movie,
            OVA
        }

        public enum AnimeGenre
        {
            Action, Adventure, Cars, Comedy, Dementia, Demons, Drama, Fantasy, Game, Harem, Historical, Horror, 
            Josei, Kids, Magic, MartialArts, Mecha, Military, Music, Mystery, Parody, Police, Psychological, Romance,
            Samurai, School, SiFi, Seinen, Shoujo, ShoujoAi, SliceOfLife, Space, Sports, SuperPower, Supernatural,
            Thriller, Vampire, Yaoi, Yuri
        }

        public int AnimeItemID { get; set; }
        public string ImageLink { get; set; }
        public string Synopsis { get; set; }
        public AnimeType Type { get; set; }
        public string TralierLink { get; set; }
        public string Openings { get; set; }
        public string Endings { get; set; }
        public string Episodes { get; set; }
        public string Aired { get; set; }
        public string Studios { get; set; }
        public AnimeGenre GenresList { get; set; }
        public string Duration { get; set; }
        public string Premiered { get; set; }
        public string InformationLink { get; set; }
    }
}
