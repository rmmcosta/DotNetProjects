using System.Data.Entity;

namespace AtTheMovie.Models
{
    public class MovieDB : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}