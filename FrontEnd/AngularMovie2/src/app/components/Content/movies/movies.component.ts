import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/Services/movie.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  movieYear!: string;
  math = Math;
  
  constructor(private movieContext: MovieService) { }
  MoviesDisplay: any = [];
  ngOnInit(): void {
    this.loadMovies();

  }
  loadMovies() {
    this.movieContext.GetMovies().subscribe((movieResult: any) => {
      console.log(movieResult);

      this.MoviesDisplay = movieResult;

    });
  }
  convertMinuteToHour(minute:number){
    var hours = this.math.floor(minute/60);
    var minutes = minute % 60;
    var duration = hours+" H : " +minutes + "M";
    return duration;
  }

}

