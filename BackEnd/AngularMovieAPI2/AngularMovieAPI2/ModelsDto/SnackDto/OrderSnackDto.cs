namespace AngularMovieAPI2.ModelsDto.SnackDto
{
    public class OrderSnackDto
    {

        public int Quantity { get; set; }
        //Navigartion Properties

        public int BookingID { get; set; }
        public int ProductID { get; set; }
    }
}
