import {HttpClient,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IMovie } from '../Interface/IMovie';
import { Router,ActivatedRoute } from '@angular/router';
import { environment } from '../environments/environment';
import {map} from 'rxjs/operators';
import { IProduct } from '../Interface/IProduct';
import { Observable } from 'rxjs';
@Injectable({
  providedIn:'root'
  })

  export class ProductService{
  public Product!:Observable<IProduct>;
  constructor(private http:HttpClient,private router:Router,private route:ActivatedRoute)// Creating a property with Variable http
  { }


//Listen what product to show.


  // Get Movies
  getProducts():Observable<any[]>{
  return this.http.get<any>(`${environment.baseUrl}/Product`);
}

 getProductById(id:number):Observable<IProduct>{
  return this.http.get<IProduct>(`${environment.baseUrl}/Product/${id}`);
}
  }
