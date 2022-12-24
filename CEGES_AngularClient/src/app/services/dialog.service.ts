import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PeriodesDialogComponent } from '../components/modals/periodesDialog/periodesDialog.component';
import Periode from '../dtos/responses/Periode';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(public dialog: MatDialog) { }



 public openPeriodesDialog(periodes: Record<string, Periode[]>, avecVariation: boolean, callback:Function ) {
    
    const dialogRef = this.dialog.open(PeriodesDialogComponent, {
      data: {
        periodes: periodes,
        avecVariation: avecVariation
      },
    });

    dialogRef.afterClosed().subscribe(result => {
      // console.log('The dialog was closed');  
      if (result) {
      // console.log('executing callback', result)

        callback(result);
      }

    });
  }
}
