import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { UserService } from 'src/app/shared/user.service';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let router: Router;
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let form : NgForm;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginComponent ],
      providers:[UserService,ToastrService],
      imports:[HttpClientTestingModule,RouterTestingModule,ToastrModule.forRoot(),FormsModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

 
  // it('testing form the proper way', fakeAsync(() => {
  //   // toastr = new ToastrService();
     
  //    fixture.detectChanges();
  //    tick();
  //    component.onSubmit(form);
      
  //    expect(router.navigateByUrl('/Dashboard'));
     
 
  //  }));

});
