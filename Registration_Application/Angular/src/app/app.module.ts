import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import {MatDialogModule} from '@angular/material/dialog';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { FormsModule } from '@angular/forms';
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CustomerService } from './shared/customer.service';
import {CustomersComponent} from 'src/app/dashboard/customers/customers.component';
import {CustomerComponent} from 'src/app/dashboard/customers/customer/customer.component';
import {CustomerListComponent} from 'src/app/dashboard/customers/customer-list/customer-list.component';
import { DialogboxComponent } from './dashboard/dialogbox/dialogbox.component';
import { UpdateComponent } from './user/update/update.component';
import { ProfileComponent } from './dashboard/profile/profile.component'



 
@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    DashboardComponent,
    CustomerComponent,
    CustomersComponent,
    CustomerListComponent,
    DialogboxComponent,
    UpdateComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      
    }),
    MatDialogModule,
    MatIconModule,
    MatFormFieldModule
  
    
  ],
  providers: [UserService,CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
