namespace AngularMovieAPI2.Models.Movie
{
    public class GenreMovie
    {
        public int GenresGenreID { get; set; }
        public int MoviesMovieID { get; set; }

        public Genre Genre { get; set; }
        public Movie Movie { get; set; }
    }
}
