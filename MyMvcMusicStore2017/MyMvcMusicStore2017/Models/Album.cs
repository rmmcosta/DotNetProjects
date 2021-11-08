using MyMvcMusicStore2017.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyMvcMusicStore2017.Models
{
    public class Album
    {
        public virtual int AlbumId { get; set; }

        [Display(Name = "Genre")]
        public virtual int GenreId { get; set; }

        [Display(Name = "Artist")]
        public virtual int ArtistId { get; set; }

        [Required(ErrorMessage = "An album without Title doesn't make any sense!")]
        [MaxWords(3)]
        public virtual string Title { get; set; }

        [Display(Name = "Album Art Url")]
        public virtual string AlbumArtUrl { get; set; }

        [Required(ErrorMessage = "Albums here are not free")]
        [Range(typeof(decimal), "0", "100")]
        public virtual decimal Price { get; set; }

        [Display(Name ="Release DateTime")]
        public virtual DateTime ReleaseDateTime { get; set; } 

        [Display(Name = "Genre")]
        public virtual Genre Genre { get; set; }

        [Display(Name = "Artist")]
        public virtual Artist Artist { get; set; }
    }

}