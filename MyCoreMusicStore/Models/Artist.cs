using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMusicStore.Models
{
    public class Artist
    {
        public virtual int ArtistId { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}
