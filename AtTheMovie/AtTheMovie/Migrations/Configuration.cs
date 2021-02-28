namespace AtTheMovie.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MovieDB context) => context.Movies.AddOrUpdate(m => m.Title,
                new Movie
                {
                    Title = "Star Wars",
                    ReleaseYear = 1977,
                    Runtime = 191
                },
                new Movie
                {
                    Title = "Inception",
                    ReleaseYear = 2010,
                    Runtime = 148
                },
                new Movie
                {
                    Title = "Toy Story",
                    ReleaseYear = 95,
                    Runtime = 81
                }
            );
    }
}
