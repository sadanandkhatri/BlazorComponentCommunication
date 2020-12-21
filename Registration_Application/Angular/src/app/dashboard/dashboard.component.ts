import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { ItemModel, MenuEventArgs, DropDownButtonComponent } from '@syncfusion/ej2-angular-splitbuttons';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { CustomerService } from '../shared/customer.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styles: [
  ]
})
export class DashboardComponent implements OnInit {
  UserProfile;
  public show: boolean = false;
 


  constructor(private router: Router, private service: CustomerService) {
  }

  ngOnInit(): void {
  

  }



  onClick() {
    this.service.openProfile().afterClosed().subscribe();
    
  }

  // Update(){
  //   //this.UserProfile.id;
  //   this.router.navigate(['user/update']);
  // }
 
}
