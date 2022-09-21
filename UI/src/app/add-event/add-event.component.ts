import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AddEventModel } from '../models/addeventmodel';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css']
})
export class AddEventComponent implements OnInit {
  minDate=new Date();
  addForm!:FormGroup;
  currentUserEmail:any=localStorage.getItem("currentUserEmail");
  event: AddEventModel={

    eventName: '',
    description: '',
    isRegistered: false,
    userEmail: this.currentUserEmail,
    eventDate: new Date,
    registrationCount: 0
  }
  constructor(private eventsservice:EventsService, private router :Router) { }

  ngOnInit(): void {
    this.eventsservice.getAllEvents();
  }
  onSubmit(){

    this.eventsservice.addEvent(this.event)
        .subscribe(
          response=>{

            console.log(response);
          }
         )
         alert("Event Added successfully!")
         this.eventsservice.getAllEvents();

        this.router.navigate(['/adminHome']);

  }

}
