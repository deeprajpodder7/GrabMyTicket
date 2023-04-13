using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AngularMovieAPI2.Models.Cinema
{
    public class Cinema
    {

        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int CinemaID { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "int")]
            [Required]
            public int TotalCinemaHalls { get; set; }

        // Navigation Properties

        public ICollection<CinemaHall> CinemaHalls { get; set; }
        [JsonIgnore]
        public int CinemaAddressID { get; set; }
        public CinemaAddress CinemaAddresses { get; set; }
    }
}
