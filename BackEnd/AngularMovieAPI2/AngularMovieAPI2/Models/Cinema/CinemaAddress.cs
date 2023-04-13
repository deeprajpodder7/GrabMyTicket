using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AngularMovieAPI2.Models.Cinema
{
    public class CinemaAddress
    {

        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int CinemaAdressID { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string Address1 { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string Address2 { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string ZipCode { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string Country { get; set; }

        // Navigation Properties

        public Cinema Cinema { get; set; }
    }
}
