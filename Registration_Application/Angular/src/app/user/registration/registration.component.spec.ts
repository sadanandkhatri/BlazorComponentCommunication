import { HttpClient, HttpHandler } from '@angular/common/http';
import{HttpClientTestingModule} from '@angular/common/http/testing';

import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormBuilder, FormsModule } from '@angular/forms';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/user.service';

import { RegistrationComponent } from './registration.component';

describe('RegistrationComponent', () => {
  let component: RegistrationComponent;
  let fixture: ComponentFixture<RegistrationComponent>;
  let toastr: ToastrService;
  

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      providers:[ToastrService,UserService,FormBuilder],
      declarations: [ RegistrationComponent ],
      imports:[ToastrModule.forRoot(),HttpClientTestingModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('testing form the proper way', fakeAsync(() => {
   // toastr = new ToastrService();
    
    fixture.detectChanges();
    tick();
    component.OnSubmit();
     
    expect(component.formModel.reset());
    

  }));


});
