import { Injectable } from '@angular/core';
import { Router, CanActivate,ActivatedRouteSnapshot,RouterStateSnapshot } from '@angular/router';

import { Observable } from 'rxjs';
import { UserService } from '../Services/user.service';


@Injectable()

export class AuthGuard implements CanActivate{
  constructor(private auth:UserService,private router:Router){}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | boolean {
      if (this.auth.isAuthenticated()) { // This is the injected auth service which depends on what you are using
           return true;
          }
      console.log('access denied!')
      this.router.navigate(['/login']);
      return false;
  }

}
