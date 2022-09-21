import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/loginmodel';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }
  token="";
  Validate(cred:LoginModel):Observable<LoginModel[]>{
  return this.http.post<LoginModel[]>('https://eventauthenticationapi.azurewebsites.net/api/Authentication',cred)
  }
}
