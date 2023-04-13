using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Models.Movie;
using AngularMovieAPI2.ModelsDto.MovieDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularMovieAPI2.Repository.MovieRepo
{
    public class MovieRepository : IMovieRepository
    {
        // Gettings Database from Dbcontext. Prevents over calling or repeating database to use data.
        private readonly ApplicationDbContext context;
        private IMapper mapper;
        public MovieRepository(ApplicationDbContext _context, IMapper _mapper) // Dependency Injection
        //Dependency Injection (DI) is a software design pattern that allows us to develop loosely coupled code.
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Movie> CreateMovie(CreateMovieModel CreateMovie)
        {
            /*
            var movie = mapper.Map<Movie>(CreateMovie);
            var MovieGenre = await context.Genres.FindAsync(CreateMovie.GenresID[0]);
            context.Genres.Add(MovieGenre);            
            context.Update(movie);
            await context.SaveChangesAsync();
            */
            // var movie = await context.Movies.Include(m => m.Genres).FirstOrDefaultAsync();
            //var genre = await context.Genres.SingleAsync(g=> g.GenreName == "Action");
            // movie.Genres.Add(genre);

            //var foo = CreateMovie;
            //foo.Genres.Clear();
            //var genre = context.Genres.SingleOrDefault(g => g.GenreID == 1); ;
            //foo.Genres.Add(genre);
            //context.Update(foo);
            //await context.SaveChangesAsync();
            //return CreateMovie;
            var CreatedMovie = CreateMovie;
            int[] Genres = CreatedMovie.GenresID;
            var Movie = mapper.Map<Movie>(CreatedMovie);
            var availableGenre = await context.Genres.ToArrayAsync();

            foreach (int item in Genres)
            {

                //var addedGenre = context.Genres.SingleOrDefault(g => g.GenreID == item);
                //Movie.Genres.Add(addedGenre);
                //Movie.Genres.Add(availableGenre
                //    .First(g => g.GenreID == item));

            }
            context.Update(Movie);

            await context.SaveChangesAsync();
            return Movie;

        }
        public async Task<Movie> UpdateMovie(UpdateMovieModel Movie)
        {
            var updatemodel = Movie;
            var UpdateMovieMap = mapper.Map<Movie>(updatemodel);
            var UpdateMovie = await context.Movies
                .Include(g => g.Genres)
                .FirstOrDefaultAsync(m => m.MovieID == UpdateMovieMap.MovieID);
            UpdateMovie.Genres.Clear();
            if (UpdateMovie == null)
            {
                throw new AppException("Movie not found");
            }

            // update Movie properties if provided
            if (!string.IsNullOrWhiteSpace(Movie.Title))
            {
                UpdateMovie.Title = Movie.Title;
            }
            if (!string.IsNullOrWhiteSpace(Movie.ImgLink))
            {
                UpdateMovie.ImgLink = Movie.ImgLink;
            }
            if (!string.IsNullOrWhiteSpace(Movie.Description))
            {
                UpdateMovie.Description = Movie.Description;
            }
            if (!string.IsNullOrWhiteSpace(Movie.ReleaseDate.ToString()))
            {
                UpdateMovie.ReleaseDate = Movie.ReleaseDate;
            }
            if (!string.IsNullOrWhiteSpace(Movie.Language))
            {
                UpdateMovie.Language = Movie.Language;
            }
            if (!string.IsNullOrWhiteSpace(Movie.Duration.ToString()))
            {
                UpdateMovie.Duration = Movie.Duration;
            }
            if (!string.IsNullOrWhiteSpace(Movie.Censorship))
            {
                UpdateMovie.Censorship = Movie.Censorship;
            }
            if (!string.IsNullOrWhiteSpace(Movie.Country))
            {
                UpdateMovie.Country = Movie.Country;
            }
            if (!string.IsNullOrWhiteSpace(Movie.GenresID.ToString()))
            {
                var availableGenre = await context.Genres.ToArrayAsync();
                int[] genreList = Movie.GenresID;
                foreach (int item in genreList)
                {
                    UpdateMovie.Genres.Add(availableGenre.First(m => m.GenreID == item));
                }
            }
            if (!string.IsNullOrWhiteSpace(Movie.TrailerLink))
            {
                UpdateMovie.TrailerLink = Movie.TrailerLink;
            }
            context.Movies.Update(UpdateMovie);
            await context.SaveChangesAsync();
            return UpdateMovie;

        }
        public async Task<IEnumerable<MovieWithGenreName>> GetMovies()
        {
            //var movie = await context.Movies.Include(m => m.Genres).ToListAsync();
            /*
            var movies = await context.Movies.Include(g => g.Genres).Select(x => new MovieWithGenreName {
                MovieID = x.MovieID,
                Title = x.Title,
                Description = x.Description,
                Duration = x.Duration,
                Language = x.Language,
                ReleaseDate = x.ReleaseDate,
                Censorship = x.Censorship,
                Country = x.Country,                
                Genres = x.Genres.Select(g=> g.GenreName).ToArray(),
                TrailerLink = x.TrailerLink
            }).ToListAsync();           
            
            var movie = await context.Movies
                .ProjectTo<MovieWithGenreName>(mapper.ConfigurationProvider)
                .Include(x => x.Genres == x.IGenre
                .Select(g=> g.GenreName) .ToArray())
                .ToListAsync();
            */
            //var movies = mapper.Map<IEnumerable<MovieWithGenreName>>(context.Movies.Include(g=>g.Genres.Select(g.));

            return await mapper.ProjectTo<MovieWithGenreName>(context.Movies).ToListAsync();
            //return movies;
        }

        public async Task<MovieWithGenreName> GetMoviesByID(int MovieID)
        {
            return await mapper.ProjectTo<MovieWithGenreName>(context.Movies)
                .Where(x => x.MovieID == MovieID)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MovieWithGenreName>> GetGenresMovie(int GenreID)
        {
            var GenreMovie = await mapper.ProjectTo<MovieWithGenreName>(context.Movies
                .Include(g => g.Genres)
                .Where(x => x.Genres.Select(g => g.GenreID)
                .Contains(GenreID)))
                .ToListAsync();

            return GenreMovie;

        }

        public async Task<Movie> DeleteMovie(int MovieID)
        {
            var getMovie = await context.Movies.FindAsync(MovieID);

            if (getMovie != null)
            {
                context.Movies.Remove(getMovie);
                await context.SaveChangesAsync();
            }
            return getMovie;
        }
    }
}
