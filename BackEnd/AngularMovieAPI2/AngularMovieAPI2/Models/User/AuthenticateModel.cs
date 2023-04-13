using System.ComponentModel.DataAnnotations;

namespace AngularMovieAPI2.Models.User
{
    public class AuthenticateModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
