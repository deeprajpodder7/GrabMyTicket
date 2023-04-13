import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, EMPTY, Observable} from 'rxjs';
import { IAuthenticationUser } from '../Interface/IAuthenticationUser';
import { IMovie } from '../Interface/IMovie';
import { Router,ActivatedRoute } from '@angular/router';
import { environment } from '../environments/environment';
import {map} from 'rxjs/operators';
@Injectable({
  providedIn:'root'
  })

  export class MovieService{
  public Movie!:Observable<IMovie>;
  constructor(private http:HttpClient,private router:Router,private route:ActivatedRoute)// Creating a property with Variable http
  { }


//Listen what product to show.


  // Get Movies
  GetMovies():Observable<any[]>{
  return this.http.get<any>(`${environment.baseUrl}/Movie`);
}

 getMovieById(id:number):Observable<IMovie>{
  return this.http.get<IMovie>(`${environment.baseUrl}/Movie/${id}`);
}
  }
