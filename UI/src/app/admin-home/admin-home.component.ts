import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EventModel } from '../models/eventmodel';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {
  pages: number = 1;
  currentUser=localStorage.getItem("currentUserName");
  currentUserEmail=localStorage.getItem("currentUserEmail");
  searchedKeyword :any ='';
  event:EventModel[]=[];
  user: string | null ='';
  constructor(private eventsservice:EventsService,private router:Router) {
    this.getAllEvents();
    this.searchedKeyword=this.currentUserEmail;
  }

  ngOnInit(): void {
  }
  getAllEvents(){
    this.eventsservice.getAllEvents().subscribe(
      response=>
      {
        this.event=response;
        console.log(this.event)
      })
  }
  deleteEvent(events:number){

    if(confirm("Are you sure you want to delete?")){
      this.eventsservice.deleteEvent(events)
    .subscribe(response=>{
    })
    alert("Event Deleted successfully!");

    }
    //this.getAllEvents();
    this.router.navigate(['/adminHome']);
    //window.location.reload();
  }

}
