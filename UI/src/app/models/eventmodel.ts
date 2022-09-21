import { Time } from "@angular/common";

export interface EventModel{
  eventId:number;
  eventName:string;
  description:string;
  isRegistered:boolean;
  userEmail:string;
  eventDate:string;

  registrationCount:number

}
