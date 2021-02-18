using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyMvcMusicStore2017.Models
{
    public class MusicStoreDBInitializer : DropCreateDatabaseAlways<MusicStoreDB>
    {
        protected override void Seed(MusicStoreDB context)
        {
            context.Artists.Add(new Artist { Name = "Ultimate Singer" });
            context.Genres.Add(new Genre { Name = "Pop" });
            context.Albums.Add(new Album
            {
                Artist = new Artist { Name = "The Best" },
                Genre = new Genre { Name="Classic"},
                Title = "Album 10",
                Price = 29.99m,
                AlbumArtUrl = "https://media.gettyimages.com/photos/listening-some-good-music-picture-id930312336?s=2048x2048"
            });
            context.Albums.Add(new Album
            {
                Artist = new Artist { Name = "Jim" },
                Genre = new Genre { Name = "Rock" },
                Title = "Album 20",
                Price = 19.99m,
                AlbumArtUrl = "https://media.gettyimages.com/photos/my-favourite-playlist-picture-id542711924?s=2048x2048"
            });
            context.Albums.Add(new Album
            {
                Artist = new Artist { Name = "Joe" },
                Genre = new Genre { Name = "Alternative" },
                Title = "Album 30",
                Price = 39.99m,
                AlbumArtUrl = "https://media.gettyimages.com/photos/beautiful-woman-sitting-on-sofa-in-living-room-picture-id1182942337?s=2048x2048"
            });
            base.Seed(context);
        }
    }
}