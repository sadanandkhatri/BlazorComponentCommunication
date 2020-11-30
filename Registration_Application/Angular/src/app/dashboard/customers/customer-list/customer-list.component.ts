import { Component, OnInit } from '@angular/core';
import { Toast, ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/shared/customer.model';
import { CustomerService } from 'src/app/shared/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  

  constructor(public custservice1 : CustomerService,private toastr : ToastrService) { }

  ngOnInit(): void {
    this.custservice1.refreshList();
    console.log(this.custservice1.list);
  }

  populateForm(cust:Customer){
    this.custservice1.formData=Object.assign({},cust);
  }

  OnDelete(custId : number){
      this.custservice1.deleteCustomer(custId).subscribe(res => 
        {
          this.custservice1.refreshList();
          this.toastr.success('Deleted Successfully','Customer Register');
      })
  }

}
