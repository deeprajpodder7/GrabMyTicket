using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AngularMovieAPI2.Models.Show;
using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.Models.User;

namespace AngularMovieAPI2.Models.Bookings
{
    public class Booking
    {
        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int BookingID { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int NumberOfSeats { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime TimeStamp { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Status { get; set; } // Enum

        // Nagvigation Property for Genre

        public int UserID { get; set; }
       public User.User user { get; set; }

        public int ShowID { get; set; }
        public Show.Show Show { get; set; }
        public ICollection<ShowSeat> ShowSeats { get; set; }
        public ICollection<OrderSnack> OrderSnacks { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
