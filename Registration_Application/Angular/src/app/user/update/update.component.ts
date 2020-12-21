import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  constructor() { }

  formModel = new FormGroup({
    UserName: new FormControl('', Validators.required),
    Email: new FormControl('', [Validators.required, Validators.email])
  });
  

  ngOnInit(): void {
  }

}
