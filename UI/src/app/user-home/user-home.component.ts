import { Component, OnInit } from '@angular/core';
import { EventModel } from '../models/eventmodel';
import { RegisterEventModel } from '../models/registerEvent';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent implements OnInit {
  event:EventModel[]=[];
  currentUserType:string| null='';
  registerevent:RegisterEventModel={
    eventId: 0,
    memberEmailId: '',
    eventName: '',
    description: '',
    eventDate: new Date
  };
  currentUserEmail=localStorage.getItem("currentUserEmail");

  user: string | null ='';
  pages: number = 1;

  constructor(private eventsservice:EventsService) { }

  ngOnInit(): void {
    this.getAllEvents();
    this.currentUserType=localStorage.getItem('currentUserType');
console.log(this.currentUserType);
  }
  getAllEvents(){
    this.currentUserType=localStorage.getItem('currentUserType');
    this.eventsservice.getAllEvents().subscribe(
      response=>
      {
        this.event=response;
      })
  }
  RegisterEvent(events:EventModel){
    events.isRegistered=true;
    this.eventsservice.RegisterEvent(events).subscribe(
      response=>{
        this.event=response;
        console.log(response);
      }
    )
    alert("Event Registered Successfully!");
  }
  DeRegisterEvent(events:EventModel){

    events.isRegistered=false;
    this.eventsservice.DeRegisterEvent(events).subscribe(
      response=>{
        this.event=response;

      }
    )
    alert("Event DeRegistered Successfully!");
  }
}
