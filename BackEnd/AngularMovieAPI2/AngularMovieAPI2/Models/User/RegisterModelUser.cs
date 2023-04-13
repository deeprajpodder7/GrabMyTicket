using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AngularMovieAPI2.Models.User
{
    public class RegisterModelUser
    {

        [Required]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(76)")]
        [Required]
        public string Password { get; set; } // Password will be Bcrypted and stored in the database.

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string EmailAddress { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        [Required]
        public string Phone { get; set; }
    }
}
