import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { User } from '../../_Classes/User';
import { ToastrService } from 'ngx-toastr';




@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent implements OnInit {
  user: User;
  constructor(private fb: FormBuilder, public service: UserService, private toastr: ToastrService) {

    this.user = new User();
    //console.log(service);
    //console.log(this.formModel);
  }


  formModel = new FormGroup({
    UserName: new FormControl('', Validators.required),
    Email: new FormControl('', [Validators.required, Validators.email]),
    Dob: new FormControl(new Date()),
    Password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    ConfirmPassword: new FormControl('', Validators.required)
 
  });

  comparePasswords(user: User) {

    if (user.Password === user.ConfirmPassword) {
      return true;
    }
    return false;
  }

  ngOnInit(): void {
    this.formModel.reset();
  }

  OnSubmit() {
    console.log(this.formModel);
    if (this.comparePasswords(this.formModel.value)) {
      this.service.register(this.formModel.value).subscribe(
        (res: any) => {
          if (res.succeeded) {
            this.formModel.reset();
            this.toastr.success('New User Created', 'Registration Successful');
          }
          else {
            res.errors.forEach(element => {
              switch (element.code) {
                case 'DuplicateUserName':
                  this.toastr.error('Username Already Taken', 'Registration Unsuccessful');
                  break;
                default:
                  this.toastr.error(element.description, 'Registration Failed');
                  break;
              }
            })
          }

        },
        err => {

          console.log(err);
        }
      );
    } else
      this.toastr.error('Password dosent match');
  }

}
