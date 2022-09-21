import { Component, OnInit } from '@angular/core';
import { AbstractControl ,FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserDetails } from '../models/usermodel';

import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  loginForm!: FormGroup;
  submitted = false;
  nowdate = new Date();
  minDate = this.nowdate.getDate();
  maxDate = this.nowdate.getDate()+14;
  users:UserDetails[]=[];
  usersignup:UserDetails={
    userId: 0,
    userEmail: '',
    firstName: '',
    lastName: '',
    password: '',
    userType: '',
    dob: new Date
  }

  constructor(private RegistrationService:RegistrationService, private router:Router, private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName:['',[Validators.required,Validators.email]],
      Fname:['',Validators.required],
      Lname:['',Validators.required],
      userType:['',Validators.required],
      Dob: ['', [Validators.required, Validators.pattern(/^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$/)]],
      passWord:['',[Validators.required,Validators.pattern(
        '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{8,25}$'
      )]]
    });
  }

  get loginData(){
    return this.loginForm.controls;
  }
  onSubmit(){
    debugger;
    this.submitted = true;
        if (this.loginForm.invalid) {
            alert("Please fill all required fields!");
            return;
        }

    if(this.usersignup.userEmail!='' && this.usersignup.password!='' && this.usersignup.userType!='')
    {
      this.RegistrationService.CreateAccount(this.usersignup)
      .subscribe(
        response=>{
          console.log(response);


        }
      )
      alert("SignUp Successfull!");
      this.router.navigate(['/login']);
    }
    else{
      // alert('Please enter your details!')

    }

    }
    onReset() {
      this.submitted = false;
      this.loginForm.reset();
  }


}
