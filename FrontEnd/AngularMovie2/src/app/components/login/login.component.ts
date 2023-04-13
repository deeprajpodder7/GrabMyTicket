import { Component, ElementRef, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs';
import { IUser } from 'src/app/Interface/IUser';
import { UserService } from 'src/app/Services/user.service';
import { PasswordFieldComponent } from '../password-field/password-field.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  UserForm!: FormGroup;
  loading = false;
  submitted = false;
  loginError = false;
  username!:string;
  passwordVisible = false;

  showErrorMessage!:string;
    constructor(private FB:FormBuilder,
      private userService:UserService,
      private router:Router,
      private route:ActivatedRoute,
      private _snackBar: MatSnackBar,private el: ElementRef)
    { }
  
    ngOnInit(): void {
      this.UserForm = this.FB.group({
        username:['',Validators.required],
        password:['',Validators.required]
      })
  
  
    }
  get authForm(){return this.UserForm.controls}
  
  
  async AuthorizeUserLogin(Model:IUser)
  {
    this.submitted = true;
  
    if(this.UserForm.invalid){
      return;
    }
  this.loading = true;
  //Pipes are simple functions to use in template expressions to accept an input value and return a transformed value.
  //Pipes are useful because we can use them throughout our application, while only declaring each pipe once.
   (
      //Pipes are simple functions to use in template expressions to accept an input value and return a transformed value.
      //Pipes are useful because we can use them throughout our application, while only declaring each pipe once.
      await this.userService.AuthorizeUserLogin(Model)).pipe(first()).subscribe({next:() =>{
     console.log(Model);
     this.username = Model.userName;
     // get return url from query parameters or default to home page
    const returnUrl = this.route.snapshot.queryParams['returnUrl']||'/';
    this.router.navigateByUrl(returnUrl);
  
   },
   error:(error: string) =>{
     this.loading = false;
     this.loginError = true;
  
     this.showErrorMessage = error;
   }
  });
  
  
  }
  
  openSnackBar(message:string) {
    this._snackBar.open(message), {
      duration: 2 * 1000,
    };
  }

  togglePasswordVisibility() {
    this.passwordVisible = !this.passwordVisible;
    const passwordField = this.el.nativeElement.querySelector('#password-field');
    passwordField.classList.toggle('hide-password');
  }
  }
  