using System.ComponentModel.DataAnnotations.Schema;

namespace AngularMovieAPI2.Models.User
{
    public class UpdateModel
    {

        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(76)")]

        public string Password { get; set; } // Password will be Bcrypted and stored in the database.

        [Column(TypeName = "nvarchar(64)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string EmailAddress { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string Phone { get; set; }
    }
}
