import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from '../_Classes/User';
import { MatDialog } from '@angular/material/dialog';
import { ProfileComponent } from '../dashboard/profile/profile.component';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor( private http: HttpClient,private dialog:MatDialog) { }
  readonly URI =  "http://localhost:63919/api"


  


  register(user: User) {

    console.log(user);
    var body = {
      UserName: user.UserName,
      Email: user.Email,
      Password: user.Password,
      Dob: user.Dob
    };

    return this.http.post(this.URI + '/Application/Register' , body);

  }
  login(formData) {
    return this.http.post(this.URI + '/Application/Login', formData);
  }

  getUserData() {
    var tokendata = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });
    return this.http.get(this.URI + '/UserProfile', { headers: tokendata });
  }
}


