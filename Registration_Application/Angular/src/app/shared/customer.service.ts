import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from './customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  formData : Customer;
  list : Customer[]; 
  readonly baseURL = "http://localhost:58497/api";
  constructor(private http : HttpClient) { }

  postCustomer(cust : Customer){
    var body = {
      fullName : cust.fullName,
      mobile: cust.mobile,
      insuranceType : cust.insuranceType,
      age : cust.age,
      gender : cust.gender
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
