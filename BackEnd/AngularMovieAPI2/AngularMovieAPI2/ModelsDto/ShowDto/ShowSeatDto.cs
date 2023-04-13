namespace AngularMovieAPI2.ModelsDto.ShowDto
{
    public class ShowSeatDto
    {
        public int Status { get; set; }

        public decimal Price { get; set; }


        // Navigation Properties
        public int ShowID { get; set; }


        public int CinemaSeatID { get; set; }


        public int? BookingID { get; set; }
    }
}
