import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IMovie } from '../Interface/IMovie';
import { Router,ActivatedRoute } from '@angular/router';
import { environment } from '../environments/environment';
import {map} from 'rxjs/operators';
import { IOrderSnack } from '../Interface/IOrderSnack';
import { Observable } from 'rxjs';
@Injectable({
  providedIn:'root'
  })

  export class OrderSnackService{
  public OrderSnack!:Observable<IOrderSnack>;
  constructor(private http:HttpClient,private router:Router,private route:ActivatedRoute)// Creating a property with Variable http
  { }


//Listen what OrderSnack to show.


  // Get Movies
  getOrderSnacks():Observable<any[]>{
  return this.http.get<any>(`${environment.baseUrl}/OrderSnack`);
}

 getOrderSnackById(id:number):Observable<IOrderSnack>{
  return this.http.get<IOrderSnack>(`${environment.baseUrl}/OrderSnack/${id}`);
}

createOrderSnack(OrderSnack:IOrderSnack){
  return this.http.post<IOrderSnack>(`${environment.baseUrl}/OrderSnack/CreateOrderSnack`,OrderSnack);
}

  }

