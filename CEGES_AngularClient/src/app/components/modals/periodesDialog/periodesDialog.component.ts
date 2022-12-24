import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import Periode from 'src/app/dtos/responses/Periode';

@Component({
  selector: 'app-periodesDialog',
  templateUrl: './periodesDialog.component.html',
  styleUrls: ['./periodesDialog.component.css']
})
export class PeriodesDialogComponent implements OnInit {


  pickedPeriode?: Periode;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<PeriodesDialogComponent>,) {
    console.log(data)
  }

  ngOnInit() { }

  setDate(periode: Periode) {
    this.pickedPeriode = periode
  }

  onOkClick() {
    this.dialogRef.close(this.pickedPeriode)
  }



}
