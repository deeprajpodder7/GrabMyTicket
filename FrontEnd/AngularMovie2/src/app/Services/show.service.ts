import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, EMPTY, Observable} from 'rxjs';
import { IAuthenticationUser } from '../Interface/IAuthenticationUser';
import { IMovie } from '../Interface/IMovie';
import { Router,ActivatedRoute } from '@angular/router';
import { environment } from '../environments/environment';
import {map} from 'rxjs/operators';
import { IShow } from '../Interface/IShow';
@Injectable({
  providedIn:'root'
  })

  export class ShowService{
  constructor(private http:HttpClient,private router:Router,private route:ActivatedRoute)// Creating a property with Variable http
  { }


//Listen what product to show.

getShowByMovieID(id:number):Observable<any[]>{
  return this.http.get<any>(`${environment.baseUrl}/Show/Movie/${id}`);
}

getShowByShowID(id:number):Observable<IShow>{
  return this.http.get<IShow>(`${environment.baseUrl}/Show/${id}`);
}

  }
