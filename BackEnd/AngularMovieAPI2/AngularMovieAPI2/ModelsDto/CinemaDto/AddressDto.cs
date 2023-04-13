using System.Text.Json.Serialization;

namespace AngularMovieAPI2.ModelsDto.CinemaDto
{
    public class AddressDto
    {
        [JsonIgnore]
        public int CinemaAdressID { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
