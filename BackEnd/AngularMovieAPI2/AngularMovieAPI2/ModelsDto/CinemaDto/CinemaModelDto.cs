using System.Text.Json.Serialization;

namespace AngularMovieAPI2.ModelsDto.CinemaDto
{
    public class CinemaModelDto
    {
        [JsonIgnore]
        public int CinemaID { get; set; }
        public string Name { get; set; }
        public int TotalCinemaHalls { get; set; }
        public AddressDto CinemaAddress { get; set; }

    }
}
