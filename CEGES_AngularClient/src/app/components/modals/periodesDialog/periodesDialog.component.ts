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
  hasPeriodes?: boolean;

  selectedPeriode ?:Periode;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<PeriodesDialogComponent>,) {
    // console.log(data)
    this.hasPeriodes = Object.keys(this.data.periodes).length ? true : false
  }

  ngOnInit() { }


  selectDate(selected: Periode) {
    this.selectedPeriode = selected;
    // if (this.avecVariation) {

    //   //deselect
    //   const index = this.selectedPeriodes.findIndex(x => x.id === selectedDate.id);
    //   if (index > -1) {
    //     //deselect the item
    //     return this.selectedPeriodes.splice(index, 1);
    //   }

    //   //mark as selected
    //   if (this.selectedPeriodes.length < 2) {
    //     return this.selectedPeriodes.push(selectedDate)
    //   }

    //   //replace oldest selected one      
    //   return this.selectedPeriodes[0] = selectedDate


    // }

    // return this.selectedPeriodes[0] = selectedDate
  }

  onOkClick() {
    return this.dialogRef.close(this.selectedPeriode)
  }



}
