import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { lastValueFrom, Subject } from 'rxjs';
import Equipement from 'src/app/dtos/responses/Equipement';
import Periode from 'src/app/dtos/responses/Periode';
import { DataService } from 'src/app/services/data.service';
import { DialogService } from 'src/app/services/dialog.service';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import Entreprise from 'src/app/dtos/requests/Entreprise';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  @Input() periodes?: Record<string, Periode[]>
  @Input() entreprise?: Entreprise;

  avecVariation = false;
  periode?: Periode;
  periodeAnterieur?: Periode;

  vartiationOptions: any[] = [{ value: 'same', text: 'mois précédent', }, { value: 'last', text: 'même mois de l’année précédente' }]
  selectedOption: string = 'same';

  displayedColumns: string[] = ['nom', 'groupe', 'type', 'emission', 'pourcentage'];
  dataSource?: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(private dataService: DataService, private dialogService: DialogService) { }

  ngOnInit() {}


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource!.filter = filterValue.trim().toLowerCase();

    if (this.dataSource?.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  fetchStatistiqueDetails(selectedPeriode: Periode) {
    this.dataService.getStatistiqueDetails(this.entreprise?.id!, selectedPeriode.id, this.avecVariation, this.selectedOption).subscribe(
      (data) => {
      
        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(data.equipements);
        this.dataSource!.paginator = this.paginator!;
        this.dataSource!.sort = this.sort!;
      },
      err => console.log(err),
      () => console.log('details completed')

    )

  }

  openDialog() {
    const callback = (selectedPeriode: any) => {
      this.fetchStatistiqueDetails(selectedPeriode)
    }
    this.dialogService.openPeriodesDialog(this.periodes!, this.avecVariation, callback);
  }


}
