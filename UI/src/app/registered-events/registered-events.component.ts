import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterEventModel } from '../models/registerEvent';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-registered-events',
  templateUrl: './registered-events.component.html',
  styleUrls: ['./registered-events.component.css']
})
export class RegisteredEventsComponent implements OnInit {

  submitted = false;
  purchasehistoryDiv:boolean=false;
  loginForm!:FormGroup;
  register:RegisterEventModel={
    eventId: 0,
    memberEmailId: '',
    eventName: '',
    description: '',
    eventDate: new Date
  }
  showHistory = false;
  history : RegisterEventModel[] = [];
  constructor(private eventsservice:EventsService,private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName:['',[Validators.required,Validators.email]],
    });

  }
  get loginData(){
    return this.loginForm.controls;
  }
  onSubmit(){
    debugger;
    this.submitted = true;
    if (this.loginForm.invalid) {
      alert("Please enter emailId!");
      return;
  }
    if(this.register.memberEmailId != '')
    {

      this.eventsservice.getRegisteredEvents(this.register.memberEmailId)
      .subscribe
      (response => {this.history = response});
      console.log(this.history);
      this.showHistory = true;
    }

  }
}
