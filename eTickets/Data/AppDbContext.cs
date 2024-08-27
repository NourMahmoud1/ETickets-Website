using eTickets.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //Relationship between Actor and Movie
            //set the primary key for the join table
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new {am.Id});
            modelBuilder.Entity<Actor_Movie>().HasOne(am => am.Actor)
                .WithMany(a => a.ActorsMovies).HasForeignKey(am => am.ActorId);
            modelBuilder.Entity<Actor_Movie>().HasOne(am => am.Movie)
                .WithMany(m => m.ActorsMovies).HasForeignKey(am => am.MovieId);
            //Relationship between Cinema and Movie
            //set the primary key for the join table
            modelBuilder.Entity<Cinema_Movie>().HasKey(cm => new {cm.Id});

            modelBuilder.Entity<Cinema_Movie>().HasOne(cm => cm.Cinema)
                .WithMany(c => c.CinemasMovies).HasForeignKey(cm => cm.CinemaId);
            modelBuilder.Entity<Cinema_Movie>().HasOne(cm => cm.Movie)
                .WithMany(m => m.CinemasMovies).HasForeignKey(cm => cm.MovieId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> ActorsMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Cinema_Movie> CinemasMovies { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
