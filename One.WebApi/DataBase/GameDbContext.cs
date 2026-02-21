using Microsoft.EntityFrameworkCore;
using One.WebApi.Entities;

namespace One.WebApi.DataBase
{
    public class GameDbContext(DbContextOptions<GameDbContext> options) :DbContext(options)
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //optionsBuilder.co

        //    }
        //}

        //public DbSet<Game> Games { get; set; }
        public DbSet<Game> Games()
        {
            return Set<Game>();
        }

        //public DbSet<Genre> Genres {  get; set; }
        public DbSet<Genre> Genres() => Set<Genre>();


        
    }
}
