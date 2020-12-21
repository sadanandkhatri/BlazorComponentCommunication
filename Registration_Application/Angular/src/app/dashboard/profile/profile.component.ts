import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  UserProfile;

  constructor(private service : UserService,private router:Router) { }

  ngOnInit(): void {
    this.service.getUserData().subscribe(
      res => {
        this.UserProfile = res;
        console.log(this.UserProfile);
      },
      err => {
        console.log(err);
      }
    )
  }

  OnLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['user/login']);
  }

  Update(){
    
  }


}
