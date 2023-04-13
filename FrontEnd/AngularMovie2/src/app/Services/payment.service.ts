import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IMovie } from '../Interface/IMovie';
import { Router,ActivatedRoute } from '@angular/router';
import { environment } from '../environments/environment';
import {map} from 'rxjs/operators';
import { IPayment } from '../Interface/IPayment';
import { Observable } from 'rxjs';
@Injectable({
  providedIn:'root'
  })

  export class PaymentService{
  public Payment!:Observable<IPayment>;
  constructor(private http:HttpClient,private router:Router,private route:ActivatedRoute)// Creating a property with Variable http
  { }


//Listen what Payment to show.


  // Get Movies
  getPayments():Observable<any[]>{
  return this.http.get<any>(`${environment.baseUrl}/Payment`);
}

 getPaymentById(id:number):Observable<IPayment>{
  return this.http.get<IPayment>(`${environment.baseUrl}/Payment/${id}`);
}

createPayment(Payment:IPayment){
  return this.http.post<IPayment>(`${environment.baseUrl}/Payment/CreatePayment`,Payment);
}

  }

