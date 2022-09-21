import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EventModel } from '../models/eventmodel';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-update-event',
  templateUrl: './update-event.component.html',
  styleUrls: ['./update-event.component.css']
})
export class UpdateEventComponent implements OnInit {
  loginForm!:FormGroup;
  mindate= new Date();
  events:EventModel[]=[];
  event:EventModel={
    eventId: 0,
    eventName: '',
    description: '',
    isRegistered: false,
    userEmail: '',
    eventDate: '',

    registrationCount: 0
  }

  constructor(private eventsservice:EventsService,private router:Router,private routers:ActivatedRoute) { }

  ngOnInit(): void {
    this.event.eventId=this.routers.snapshot.params['eventId']
    // console.log(this.id)
    this.GetEventById();
  }
  updateEvent(){

    this.eventsservice.updateEvent(this.event)
        .subscribe(
          response=>{
            console.log(response);

          }
         )
         alert("Event Updated Successfully!")
         this.GetEventById();
        this.router.navigate(['/adminHome']);
  }
  GetEventById(){

    this.eventsservice.getEventsById(this.event.eventId)
    .subscribe
    ((response : any)=>
    {
      this.event=response;

    })
  }

}
