import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  token=localStorage.getItem("token");
  currentusername:any;
  title = 'event-managementApp';

  constructor(private router:Router){

  }
  ngOnInit(): void {
    this.currentusername=localStorage.getItem("currentUserName");
  }

  loggedin(){
    this.currentusername=localStorage.getItem("currentUserName");
    return !!localStorage.getItem('token');
  }
  logout(){
    localStorage.clear();
    this.currentusername=localStorage.getItem("currentUserName");
    localStorage.removeItem('token');

    this.router.navigate(['/login']);

  }
  checkloggedin(){
    debugger;
    if(localStorage.getItem('token')==null)
    {
      alert("Please login to proceed!")
      this.router.navigate(['/login']);
    }
    else{
      this.router.navigate(['/userHome']);
    }
  }
}
