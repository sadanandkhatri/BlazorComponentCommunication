import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CustomerService } from 'src/app/shared/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(public custservice : CustomerService,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.resetform();
  }

  resetform(form? : NgForm){

    if(form != null)
      form.resetForm();

    this.custservice.formData = {
      custId : null,
      fullName : '',
      insuranceType:'',
      mobile:'',
      age: 0,
      gender : ''
      }
  }

  onSubmit(form : NgForm){
    if(form.value.custId == null){
      this.insertRecord(form);
    }
    else{
        this.updateRecord(form);
      }
    this.custservice.refreshList();
  }

  insertRecord(form:NgForm){
      this.custservice.postCustomer(form.value).subscribe(res => {
        this.toastr.success('Inserted successfully','Customer Register');
        this.resetform(form);
        this.custservice.refreshList();
      },
      err => {
        console.log(err);
      });
    
      
  }

  updateRecord(form: NgForm){
    this.custservice.putCustomer(form.value).subscribe(res => {
      this.toastr.success('Updated successfully','Customer Register');
      this.resetform(form);
      this.custservice.refreshList();
    },
    err => {
      console.log(err);
    });
  }

}
