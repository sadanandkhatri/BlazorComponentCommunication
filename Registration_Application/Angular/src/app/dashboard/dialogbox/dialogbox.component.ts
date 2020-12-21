import { Component, OnInit } from '@angular/core';

import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dialogbox',
  templateUrl: './dialogbox.component.html',
  styleUrls: ['./dialogbox.component.css']
})
export class DialogboxComponent implements OnInit {

  constructor(public dialogref : MatDialogRef<DialogboxComponent>) { }

  ngOnInit(): void {
  }

  closeDialog(){
    this.dialogref.close(false);
  }

}
