import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { IBooking } from 'src/app/Interface/IBooking';
import { IMovie } from 'src/app/Interface/IMovie';
import { IPayment } from 'src/app/Interface/IPayment';
import { IShow } from 'src/app/Interface/IShow';
import { IUser } from 'src/app/Interface/IUser';
import { BookingService } from 'src/app/Services/booking.service';
import { MovieService } from 'src/app/Services/movie.service';
import { PaymentService } from 'src/app/Services/payment.service';
import { ShowService } from 'src/app/Services/show.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-my-history',
  templateUrl: './my-history.component.html',
  styleUrls: ['./my-history.component.css']
})
export class MyHistoryComponent implements OnInit {

  ShowID!: number;
  MovieID!: number;
  BookingID!: number;
  PaymentID!: number;
  UserID!:number;
  Movie!: IMovie;
  Payment!: IPayment;
  Show!: IShow;
  User!:IUser;
  Booking!:IBooking[];
  constructor(
    private route: ActivatedRoute,
    private movieContext: MovieService,
    private showContext: ShowService,
    private bookingContext: BookingService,
    private paymentContext: PaymentService,
    private router: Router,
    private userService:UserService


  ) { }

  ngOnInit(): void {

   this.User = this.userService.userValue;
    this.getBookings()
  }

  getShow(id:number) {
    var moviename = "";
    this.showContext.getShowByShowID(id).subscribe((showResult) => {
      this.Show = showResult;
      moviename= this.getMovie(showResult.movieID);
    }
    );
    console.log(moviename)
    return moviename;
  }
  movieName(showID:number){
  return this.getShow(showID);
  }
getBookings(){
  this.bookingContext.getBookingByUserId(this.User.userID).subscribe((bookingResult)=>{
    this.Booking = bookingResult;
    console.log(bookingResult)
  })
}

  getMovie(movieID:number) {
    var moviename= "";
    this.movieContext.getMovieById(movieID).subscribe((movieResult) => {
      this.Movie = movieResult;
      moviename = movieResult.title;
    });
    console.log(moviename)
    return moviename;
  }

}
