import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDetails } from '../models/usermodel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private http:HttpClient) { }
  CreateAccount(usersignup:UserDetails):Observable<UserDetails[]>{
    debugger;
    return this.http.post<UserDetails[]>('https://eventportaladminapi.azurewebsites.net/Admin/CreateAccount',usersignup);
  }
}
