import { Injectable } from "@angular/core";
import { HttpRequest,HttpHandler,HttpEvent,HttpInterceptor } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserService } from "../Services/user.service";
import { environment } from "../environments/environment";

@
Injectable()
export class JwtInterceptor implements
HttpInterceptor{
  constructor(private userService:UserService){}

  intercept(request:HttpRequest<any>,next:
    HttpHandler): Observable<HttpEvent<any>>{
      // add auth header with jwt if user is logged in and request is to the api url
      const user = this.userService.userValue;
      const isLoggedIn = user && user.token;
      const isApiUri = request.url.startsWith(environment.baseUrl);
      if(isLoggedIn && isApiUri){
        request = request.clone({
          setHeaders:{
            Authorization:`Bearer ${user.token}`
          }
        });
      }

      return next.handle(request);
    }
}
