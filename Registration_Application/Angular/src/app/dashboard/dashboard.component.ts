import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { ItemModel, MenuEventArgs, DropDownButtonComponent } from '@syncfusion/ej2-angular-splitbuttons';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styles: [
  ]
})
export class DashboardComponent implements OnInit {
  UserProfile;
  public show: boolean = false;
 


  constructor(private router: Router, private service: UserService) {
  }

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


  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['user/login']);
  }

  onClick() {
    console.log(this.show);
    this.show = !this.show;
    console.log(this.show);
    
  }
 
}
