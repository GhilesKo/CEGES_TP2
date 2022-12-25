import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-errorDialog',
  templateUrl: './errorDialog.component.html',
  styleUrls: ['./errorDialog.component.css']
})
export class ErrorDialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<ErrorDialogComponent>) { }

  ngOnInit() {
  }

}
