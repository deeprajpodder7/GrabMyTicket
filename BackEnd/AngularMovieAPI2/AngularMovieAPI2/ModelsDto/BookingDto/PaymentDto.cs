namespace AngularMovieAPI2.ModelsDto.BookingDto
{
    public class PaymentDto
    {

        public decimal Amount { get; set; }

        public DateTime TimeStamp { get; set; }

        public int DiscountCuponID { get; set; }


        public int PaymentMethod { get; set; } // Enum

        // Nagvigation Property for Genre
        public int BookingID { get; set; }
    }
}
