namespace AngularMovieAPI2.ModelsDto.MovieDto
{
    public class MovieWithGenreName
    {
        public int MovieID { get; set; }

        public string Title { get; set; }

        public string ImgLink { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public string Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Censorship { get; set; }

        public string Country { get; set; }

        // Foreign Key for Genre
        public string[] Genres { get; set; }
        public string TrailerLink { get; set; }
    }
}
