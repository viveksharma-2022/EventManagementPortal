import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddEventModel } from '../models/addeventmodel';
import { EventModel } from '../models/eventmodel';

@Injectable({
  providedIn: 'root'
})
export class EventsService {
  token=localStorage.getItem('token');
   //baseUrl='https://localhost:7160/Admin/';
  baseUrl='https://eventportaladminapi.azurewebsites.net/Admin/';
  currentUserEmail:any=localStorage.getItem('currentUserEmail');
  httpheader = new HttpHeaders(
    {
        'Authorization': 'Bearer ' + this.token,
        'Content-Type': 'application/json'
    })

  constructor(private http: HttpClient) { }

  getAllEvents():Observable<EventModel[]> {

    return this.http.get<EventModel[]>(this.baseUrl+'GetAllEvents');
  }

  getEventsById(id:number):Observable<any> {

    return this.http.get<any>(this.baseUrl+'GetEventById/'+id);
  }
  updateEvent(event: EventModel):Observable<EventModel[]> {

    return this.http.put<EventModel[]>(this.baseUrl+'UpdateEvent',event, {headers : this.httpheader});
  }
  addEvent(event: AddEventModel):Observable<AddEventModel[]> {

    return this.http.post<AddEventModel[]>(this.baseUrl+'AddEvent',event, {headers : this.httpheader});
  }
  deleteEvent(event: number):Observable<number> {

    return this.http.delete<number>(this.baseUrl+'DeleteEvent/'+event);
  }
  getRegisteredEvents(email:any):Observable<any>{

    return this.http.get<any[]>('https://eventportaladminapi.azurewebsites.net/Member/GetAllRegisteredEvents/'+email);

  }
  RegisterEvent(events: EventModel):Observable<EventModel[]>{
    let queryParams = new HttpParams();
      queryParams = queryParams.append("currentUserEmail",this.currentUserEmail)
      queryParams = queryParams.append("eventId",events.eventId);
      queryParams = queryParams.append("eventName",events.eventName);
      queryParams = queryParams.append("description",events.description);
      queryParams = queryParams.append("eventDate",events.eventDate);

    return this.http.get<EventModel[]>('https://eventportaladminapi.azurewebsites.net/Member/RegisterEvent',{params:queryParams});
}
DeRegisterEvent(events:EventModel):Observable<EventModel[]>{
  let queryParams = new HttpParams();
      queryParams = queryParams.append("currentUserEmail",this.currentUserEmail)
      queryParams = queryParams.append("eventId",events.eventId);
      queryParams = queryParams.append("eventName",events.eventName);
      queryParams = queryParams.append("description",events.description);
      queryParams = queryParams.append("eventDate",events.eventDate);
      debugger;
    return this.http.get<EventModel[]>('https://eventportaladminapi.azurewebsites.net/Member/DeRegisterEvent',{params:queryParams});
}

}
