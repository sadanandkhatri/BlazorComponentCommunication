import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from './customer.model';
import {MatDialog, MatDialogRef} from '@angular/material/dialog'
import { DialogboxComponent } from '../dashboard/dialogbox/dialogbox.component';
import { ProfileComponent } from '../dashboard/profile/profile.component';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  formData : Customer;
  list : Customer[]; 
  readonly baseURL = "http://localhost:58497/api";
  constructor(private http : HttpClient, private dialog:MatDialog) { }


  openProfile(){
    //this.dialog.updatePosition({ top: '50px', left: '50px' });
    return this.dialog.open(ProfileComponent,{
      width:'290px',
      position:{top:'50px',right:'10px'},
      disableClose:false

      //panelClass:'confirm-dialog-container'
    });
  }

  openConfirmDialogbox(){
    return this.dialog.open(DialogboxComponent,{
      width:'390px',
      panelClass:'confirm-dialog-container',
      disableClose:true
    });
  }

  postCustomer(cust : Customer){
    var body = {
      fullName : cust.fullName,
      mobile: cust.mobile,
      insuranceType : cust.insuranceType,
      age : cust.age,
      gender : cust.gender,
      matdate : cust.matdate,
      Amount : cust.Amount
    }
    return this.http.post(this.baseURL+'/Customer',body);

  }

  refreshList(){
    this.http.get(this.baseURL+'/Customer').toPromise().then(res => {this.list = res as Customer[] ;console.log(res);} );
    console.log(this.list);
  }

  putCustomer(cust : Customer){
    
    return this.http.put(this.baseURL+'/Customer/'+ cust.custId,cust);

  }

  deleteCustomer(custId : number){
      return this.http.delete(this.baseURL+'/Customer/' + custId);
  }
}
