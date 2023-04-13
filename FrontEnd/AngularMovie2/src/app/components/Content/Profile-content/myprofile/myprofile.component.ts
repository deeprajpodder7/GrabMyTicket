import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IUser } from 'src/app/Interface/IUser';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-myprofile',
  templateUrl: './myprofile.component.html',
  styleUrls: ['./myprofile.component.css']
})
export class MyprofileComponent implements OnInit {
  user!:IUser;
  displayForm!:FormGroup;
  constructor(private userService:UserService,private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.user = this.userService.userValue;
    this.displayForm = this.formBuilder.group({
      firstName:['',Validators.required],
       lastName:['',Validators.required],
       userName:['',Validators.required],
       emailAddress:['',Validators.required],
       phone:['',Validators.required],
       dateCreated:[Date,Validators.required]
    });

    this.displayForm.patchValue(this.user);
    this.displayForm.disable();
  }



}
