using AngularMovieAPI2.Models.Bookings;
using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.Models.Movie;
using AngularMovieAPI2.Models.Show;
using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.Models.User;
using AngularMovieAPI2.ModelsDto.BookingDto;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AngularMovieAPI2.ModelsDto.GenreDto;
using AngularMovieAPI2.ModelsDto.MovieDto;
using AngularMovieAPI2.ModelsDto.ShowDto;
using AngularMovieAPI2.ModelsDto.SnackDto;
using AutoMapper;

namespace AngularMovieAPI2.Helper
{
    //The automapper profile contains the mapping configuration used by the application, AutoMapper is a package available on Nuget that enables automatic mapping of one type of classes to another.
    //In this example we're using it to map between User entities and a few different model types - UserModel, RegisterModel and UpdateModel.
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<RegisterModelUser, User>().ReverseMap();
            CreateMap<UpdateModel, User>().ReverseMap();
            //CreateMap<MovieWithGenreName, Movie>().ReverseMap();
            // This will Map the remaning property and in this case Gernes Names will be stored in an array from Collection Genre.
            CreateMap<Movie, MovieWithGenreName>()
                .ForMember(movie => movie.Genres,
                igenre => igenre.MapFrom(genre => genre.Genres
                .Select(g => g.GenreName).ToArray())).ReverseMap();
            //CreateMap<MovieWithGenreName, Movie>().ReverseMap();
            //    .ForMember(Movie => Movie.Genres, Igenre => Igenre.MapFrom(genre => new Genre() { }));
            CreateMap<CreateMovieModel, Movie>().ReverseMap();
            CreateMap<UpdateMovieModel, Movie>().ReverseMap();
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
            CreateMap<CreateGenre, Genre>().ReverseMap();
            CreateMap<CinemaAddress, AddressDto>().ReverseMap();
            CreateMap<Cinema, CinemaModelDto>().ReverseMap();
            CreateMap<CinemaSeat, CinemaSeatModelDto>().ReverseMap();
            CreateMap<CinemaHall, CinemaHallDto>().ReverseMap();
            CreateMap<Show, ShowDetailsDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<ShowSeat, ShowSeatDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<OrderSnack, OrderSnackDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }
    }
}
