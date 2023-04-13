using AngularMovieAPI2.Models.Bookings;
using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.Models.Movie;
using AngularMovieAPI2.Models.Show;
using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.Models.User;
using Microsoft.EntityFrameworkCore;

namespace AngularMovieAPI2.Environment
{
    public class ApplicationDbContext:DbContext
    {

        //Application Db Constructor. Base options Connection string will be set in Statup Class.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //  Migrating Database Table Users into SqlDatabase.
        // USER DATABASES
        public DbSet<User> Users { get; set; }
        // MOVIE DATABASES
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMovie> GenreMovie { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowSeat> ShowSeats { get; set; }
        public DbSet<OrderSnack> OrderSnacks { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaAddress> CinemaAddresses { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<CinemaSeat> CinemaSeats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }

        // Relationship Configuring via the Fluent API for EF Core to be able to map it successfully.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Movie Model Building
            modelBuilder.Entity<Movie>().HasMany(x => x.Genres)
                .WithMany(x => x.Movies)
                .UsingEntity<GenreMovie>(
                    x => x.HasOne(x => x.Genre)
                    .WithMany().HasForeignKey(x => x.GenresGenreID),
                    x => x.HasOne(x => x.Movie)
                   .WithMany().HasForeignKey(x => x.MoviesMovieID));

        }

    }
}
