import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { IUser } from 'src/app/Interface/IUser';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {
  editForm!:FormGroup;
  id!:number;
  loading = false;
  submitted = false;
  user!:IUser;
  constructor(
    private formBuilder:FormBuilder,
    private route:ActivatedRoute,
    private router:Router,
    private userService:UserService
  ) { }

  ngOnInit(): void {
    this.userService.user.subscribe(x=> this.user = x);
   // this.user = this.userService.userValue;
    this.id = this.user.userID;
    // Password is not required in edit mode.
    const passwordValidators =[Validators.minLength(6)];
    this.editForm = this.formBuilder.group({
      firstName:['',Validators.required],
       lastName:['',Validators.required],
       userName:['',Validators.required],
       password:['',passwordValidators],
       emailAddress:['',Validators.required],
       phone:['',Validators.required],
       dateCreated:[Date,Validators.required]
    });

    this.editForm.patchValue(this.user);
    //this.userService.getUserById(this.id).pipe(first()).subscribe(x=> this.editForm.patchValue(x));
  }
  // convenience getter for easy access to form fields.
  get editValues(){
    return this.editForm.controls;
  }

 async  onSubmit(){
     this.submitted = true;
     // Stops here if form is invalid.
     if(this.editForm.invalid){
      return;

     }
   this.loading =true;
   this.editForm.value.dateCreated = this.user.dateCreated;
   (await this.userService.update(this.id, this.editForm.value)).pipe
   (first()).subscribe({
     next:() => {
       console.log("UPDATE SUCCESSFUL"),{keepAfterRouteChange :true};
       this.router.navigate(['../../'],{relativeTo:this.route});
     },
     error: error => {
       this.loading = false;
       console.error(error);
     }
   })

   }
}
