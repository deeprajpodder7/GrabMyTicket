namespace AngularMovieAPI2.ModelsDto.CinemaDto
{
    public class CinemaSeatModelDto
    {
        public int SeatNumber { get; set; }

        public int type { get; set; } //ENUM

        // Navigation Property
        public int CinemaHallID { get; set; }
    }
}
