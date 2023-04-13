import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IMovie } from 'src/app/Interface/IMovie';
import { IPayment } from 'src/app/Interface/IPayment';
import { IShow } from 'src/app/Interface/IShow';
import { BookingService } from 'src/app/Services/booking.service';
import { MovieService } from 'src/app/Services/movie.service';
import { PaymentService } from 'src/app/Services/payment.service';
import { ShowService } from 'src/app/Services/show.service';

@Component({
  selector: 'app-booking-nav',
  templateUrl: './booking-nav.component.html',
  styleUrls: ['./booking-nav.component.css']
})
export class BookingNavComponent implements OnInit {
  ShowID!:number;
  MovieID!:number;
  BookingID!:number;
  PaymentID!:number;
  Movie!:IMovie;
  Payment!:IPayment;
  Show!:IShow;
  math!: Math;


  constructor(
    private route:ActivatedRoute,
    private movieContext:MovieService,
    private showContext:ShowService,
    private bookingContext:BookingService,
    private paymentContext:PaymentService,
    private router:Router


    ) { }

  ngOnInit(): void {
   this.route.params.subscribe((params: { [x: string]: number; })=> {this.ShowID = params['showID']; this.MovieID = params['movieID'];this.BookingID =params['bookingID'], this.PaymentID =params['ticketID']});
    console.log(this.ShowID,this.MovieID,this.BookingID)
    this.getMovie();
    this.getPayment();
    this.getShow()
  }

  getShow(){
    this.showContext.getShowByShowID(this.ShowID).subscribe((showResult: any)=>
    {
      this.Show = showResult;
    }
    );
  }

  getMovie(){
    this.movieContext.getMovieById(this.MovieID).subscribe((movieResult: any)=>
    {
      this.Movie = movieResult;
      console.log(movieResult);
    });


  }
  getPayment(){
    this.paymentContext.getPaymentById(this.PaymentID).subscribe((paymentResult: any)=>{
      this.Payment = paymentResult;
    })
  }

  onPay(){

  }
  convertMinuteToHour(minute:number){
    var hours = this.math.floor(minute/60);
    var minutes = minute % 60;
    var duration = hours+" H : " +minutes + "M";
    return duration;
  }
}
