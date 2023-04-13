using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AngularMovieAPI2.Models.Bookings
{
    public class Payment
    {
        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int PaymentID { get; set; }

        [Column(TypeName = "decimal")]
        [Required]
        public decimal Amount { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime TimeStamp { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int DiscountCuponID { get; set; }


        [Column(TypeName = "int")]
        [Required]
        public int PaymentMethod { get; set; } // Enum

        // Nagvigation Property for Genre
        [ForeignKey("Booking")]
        public int BookingID { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
