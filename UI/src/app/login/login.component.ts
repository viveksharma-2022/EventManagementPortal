import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginModel } from '../models/loginmodel';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  submitted = false;
  isAuthenticated:boolean=false;
  currentUserName:string='';
  currentUserEmail:string='';
  currentUserId:string='';
  currentUserType:string='';
  usernamediv:boolean=false;
  passdiv:boolean=false;
  token : any={
    token:'',
    isAuthenticated:false,
    UserType:''
  }
  cred:LoginModel={
    userEmail:"",
    password:""
  }

  constructor(private loginservice:LoginService, private router:Router, private formBuilder:FormBuilder) { }
  jwthelper = new JwtHelperService();

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName:['',[Validators.required,Validators.email]],
      passWord:['',[Validators.required,Validators.pattern(
        '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{8,25}$'
      )]]
    });
  }
  get loginData(){
    return this.loginForm.controls;
  }
  onSubmit(){
    this.submitted=true;
    if(this.cred.userEmail!='' && this.cred.password!='')
    {

      this.loginservice.Validate(this.cred)
      .subscribe(
        response=>
        {

          this.token=response;
          const decodedToken=this.jwthelper.decodeToken(this.token.token);

          this.isAuthenticated=this.token.isAuthenticated;
          this.currentUserName=decodedToken.FirstName;
          this.currentUserType=decodedToken.Usertype;
          this.currentUserEmail=decodedToken.UserEmail;
          localStorage.setItem("token",this.token.token);
          localStorage.setItem("signinnavlink",this.isAuthenticated?"true":"false");
          localStorage.setItem("currentUserName",this.currentUserName);
          localStorage.setItem("currentUserType",this.currentUserType);
          localStorage.setItem("currentUserEmail",this.currentUserEmail);
          localStorage.setItem("isAutheticated",this.isAuthenticated?"true":"false");
          if(this.token=='')
          {
            alert('EmailId or Password is incorect');
            return;
          }

          if(this.currentUserType==="Admin")
          {
            // alert("Admin Login Successful!");
            this.router.navigate(['/adminHome']);
          }
          else{
            // alert("Member Login Successful!");
            this.router.navigate(['/userHome']);
          }

        },
        error=>{
          alert("EmailId or Password is incorrect!");
        }
      )
    }
  }

}
