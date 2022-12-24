import { Component, Input, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { lastValueFrom, Subject } from 'rxjs';
import Equipement from 'src/app/dtos/responses/Equipement';
import Periode from 'src/app/dtos/responses/Periode';
import { DataService } from 'src/app/services/data.service';
import { DialogService } from 'src/app/services/dialog.service';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit, AfterViewInit {
  @Input() periodes?: Record<string, Periode[]>
  @Input() entrepriseId?: number;


  avecVariation = false;
  periode?: Periode;
  periodeAnterieur?: Periode;

  // equipements: Equipement[] = [];
  // constructor(public nom: string, public periodeId: number, public groupe: string, public type: string, public emission: number) {

  displayedColumns: string[] = ['nom', 'groupe', 'type', 'emission', 'pourcentage'];
  dataSource?: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;


  constructor(private dataService: DataService, private dialogService: DialogService) { }

  ngOnInit() { }
  ngAfterViewInit(): void {

  }




  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource!.filter = filterValue.trim().toLowerCase();

    if (this.dataSource?.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  fetchStatistiqueDetails() {

    if (!this.avecVariation) {
      if (this.periode) {
        this.dataService.getStatistiqueDetails(this.entrepriseId!, this.periode?.id, this.avecVariation).subscribe(
          data => {
            const total = data.emissionTotal;
            const mappedEquipements = data.equipements.map((e: Equipement) => {
              const pourcentage = e.emission / total * 100
              const equipement = {
                ...e,
                pourcentage: pourcentage.toFixed(2)
              }
              return equipement
            })

            // console.log(this.equipements)
            // Assign the data to the data source for the table to render
            this.dataSource = new MatTableDataSource(mappedEquipements);
            this.dataSource!.paginator = this.paginator!;
            this.dataSource!.sort = this.sort!;
          },
          err => console.log(err),
          () => console.log('details completed')

        )
      }
      return;

    }


    if (this.periode && this.periodeAnterieur) {
      this.dataService.getStatistiqueSommaire(this.entrepriseId!, this.periode.id, this.avecVariation, this.periodeAnterieur.id).subscribe(
        res => console.log(res),
        err => console.log(err),
        () => console.log(),
      )
    }

  }

  openPeriodesDialog() {

    const callback = (pickedPeriode: any) => {
      this.periode = pickedPeriode;
      this.fetchStatistiqueDetails()
    }

    this.dialogService.openPeriodesDialog(this.periodes!, this.avecVariation, callback);

  }


}
