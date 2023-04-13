using AngularMovieAPI2.Models.Movie;
using System.Text.Json.Serialization;

namespace AngularMovieAPI2.ModelsDto.MovieDto
{
    public class CreateMovieModel
    {
        [JsonIgnore]
        public int MovieID { get; set; }
        public string Title { get; set; }

        public string ImgLink { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public string Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Censorship { get; set; }

        public string Country { get; set; }
        //[JsonIgnore]
        //public ICollection<Genre> Genres { get; set; }


        // Foreign Key for Genre
        public int[] GenresID { get; set; }
        public string TrailerLink { get; set; }
    }
}
