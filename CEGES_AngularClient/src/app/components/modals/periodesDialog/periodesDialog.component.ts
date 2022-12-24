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
  hasPeriodes?:boolean;
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<PeriodesDialogComponent>,) {
    // console.log(data)
    this.hasPeriodes = Object.keys(this.data.periodes).length ? true : false
  }

  ngOnInit() { }

  setDate(periode: Periode) {
    this.pickedPeriode = periode
  }

  onOkClick() {
    this.dialogRef.close(this.pickedPeriode)
  }



}
