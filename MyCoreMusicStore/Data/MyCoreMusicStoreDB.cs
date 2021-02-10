using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCoreMusicStore.Models;

namespace MyCoreMusicStore.Data
{
    public class MyCoreMusicStoreDB : DbContext
    {
        public MyCoreMusicStoreDB (DbContextOptions<MyCoreMusicStoreDB> options)
            : base(options)
        {
        }

        public DbSet<MyCoreMusicStore.Models.Album> Album { get; set; }

        public DbSet<MyCoreMusicStore.Models.Artist> Artist { get; set; }

        public DbSet<MyCoreMusicStore.Models.Genre> Genre { get; set; }
    }
}
