import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IMovie } from '../Interface/IMovie';
import { Router,ActivatedRoute } from '@angular/router';
import { environment } from '../environments/environment';
import {map} from 'rxjs/operators';
import { IShowSeat } from '../Interface/IShowSeat';
import { Observable } from 'rxjs';
import { IShow } from '../Interface/IShow';
@Injectable({
  providedIn:'root'
  })

  export class ShowSeatService{
  public ShowSeat!:Observable<IShowSeat>;
  constructor(private http:HttpClient,private router:Router,private route:ActivatedRoute)// Creating a property with Variable http
  { }


//Listen what product to show.


  // Get Movies
  getShowSeats():Observable<any[]>{
  return this.http.get<any>(`${environment.baseUrl}/ShowSeat`);
}

 getShowSeatById(id:number):Observable<IShow>{
  return this.http.get<IShow>(`${environment.baseUrl}/ShowSeat/${id}`);
}

getShowSeatsByShowID(id:number):Observable<any[]>{
  return this.http.get<any>(`${environment.baseUrl}/ShowSeat/Show/${id}`)

}
  updateShowSeat(id:number,showSeat:IShowSeat){
  return this.http.put<IShowSeat>(`${environment.baseUrl}/ShowSeat/UpdateShowSeat/${id}`,showSeat);
  }

  }
