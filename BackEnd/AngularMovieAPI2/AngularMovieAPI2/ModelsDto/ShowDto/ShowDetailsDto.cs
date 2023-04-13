namespace AngularMovieAPI2.ModelsDto.ShowDto
{
    public class ShowDetailsDto
    {
        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int MovieID { get; set; }
        public int CinemaHallID { get; set; }
    }
}
