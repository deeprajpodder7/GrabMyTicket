using System.Text.Json.Serialization;

namespace AngularMovieAPI2.Models.User
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }
        [JsonIgnore] // Ignoring password data to be not shown.
        public string Password { get; set; } // Password will be Bcrypted and stored in the database.

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime DateCreated { get; set; }

        public string Phone { get; set; }
        public string Token { get; set; }
    }
}
