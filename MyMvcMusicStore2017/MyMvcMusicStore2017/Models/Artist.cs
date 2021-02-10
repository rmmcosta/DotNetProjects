namespace MyMvcMusicStore2017.Models
{
    using System.Collections.Generic;

    public class Artist
    {
        public virtual int ArtistId { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}