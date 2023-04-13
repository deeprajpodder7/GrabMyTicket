import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IMovie } from 'src/app/Interface/IMovie';
import { MovieService } from 'src/app/Services/movie.service';
import { ShowService } from 'src/app/Services/show.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  math = Math;
  MovieId!:number;
  Movie!:IMovie;
  selected!: Date;
  week = new Array(7).fill(new Date());
  shows:any =[];
  constructor(
    private route:ActivatedRoute,
    private movieContext:MovieService,
    private showContext:ShowService) {

    }

  ngOnInit(): void {
   this.route.params.subscribe((params: { [x: string]: number; })=> this.MovieId = params['id']);
    this.movieDetails(this.MovieId);
    this.getNextWeek();
    this.getShows();
    this.selected = new Date();
    
  }

  movieDetails(id:number){
    this.movieContext.getMovieById(id).subscribe((movieResult: any)=>
    {this.Movie = movieResult;
    console.log(movieResult)
   });

  }

  getNextWeek(){
   var date = new Date();
    for(let i =0;i<7;i++){
      this.week[i] = new Date(date.getFullYear(),date.getMonth(),date.getDate()+i);
    }

  }

  getShows(){
    this.showContext.getShowByMovieID(this.MovieId).subscribe((showResult: any)=>
    { console.log(showResult);
      this.shows = showResult;
    })
  }

  convertMinuteToHour(minute:number){
    var hours = this.math.floor(minute/60);
    var minutes = minute % 60;
    var duration = hours+" H : " +minutes + "M";
    return duration;
  }
}
