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
import Variation from 'src/app/models/variation';
import EntrepriseDetailsAvecVariation from 'src/app/dtos/responses/EntrepriseDetailsAvecVariation';
import { IfStmt } from '@angular/compiler';

const defaultColumns = ['nom', 'groupe', 'type', 'emission', 'pourcentage'];

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  @Input() periodes?: Record<string, Periode[]>
  @Input() entreprise?: Entreprise;


  avecVariation = false;

  selectedPeriode?: Periode;


  vartiationOptions: any[] = [{ value: 'same', text: 'mois précédent', }, { value: 'last', text: 'même mois de l’année précédente' }]
  selectedOption: string = 'same';

  displayedColumns: string[] = defaultColumns;
  dataSource?: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;




  constructor(private dataService: DataService, private dialogService: DialogService) { }

  ngOnInit() { }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource!.filter = filterValue.trim().toLowerCase();

    if (this.dataSource?.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  fetchStatistiqueDetails(selectedPeriode: Periode) {
    this.dataService.getStatistiqueDetails(this.entreprise?.id!, selectedPeriode.id, this.avecVariation, this.selectedOption).subscribe(
      (data: EntrepriseDetailsAvecVariation) => {
        this.selectedPeriode = selectedPeriode;

        let equipements: Equipement[] | any[]

        if (this.avecVariation) {
          equipements = data.equipements.map(e => {
            return {
              ...e,
              variation: this.calculateVariation(e.emission, e.emissionAnterieure)
            }


          })
          this.displayedColumns = [...defaultColumns, 'variation']
        } else {
          equipements = data.equipements
          this.displayedColumns = [...defaultColumns]
        }

        // Assign the data to the data source for the table to render
        this.dataSource = new MatTableDataSource(equipements);
        this.dataSource!.paginator = this.paginator!;
        this.dataSource!.sort = this.sort!;
        this.dataSource.sortingDataAccessor = (item, property) => {
          switch (property) {
            case 'variation': {
              return (item.variation as Variation).value;
            }
            default: {
              return item[property];
            }
          };
        }

      },
      err => {
        console.log(err);
        this.dialogService.openErrorDialog(`Aucune periode anterieure à ${selectedPeriode.nom}`)
        
       },
      () => console.log('fetchStatistiqueDetails completed')

    )

  }

  openDialog() {
    const callback = (selectedPeriode: any) => {
      this.fetchStatistiqueDetails(selectedPeriode)
    }
    this.dialogService.openPeriodesDialog(this.periodes!, this.avecVariation, callback);
  }

  private calculateVariation(original: number, newValue: number): Variation {
    // % increase = Increase ÷ Original Number × 100.
    // console.log(`total: ${original}`, `totalAnterieure: ${newValue}`)
    let type;
    const increase = newValue - original;
    const increasePourcentage = increase / original * 100
    // check if number is greater than 0
    if (increase > 0) {
      // console.log("The number has increase");
      type = 'increase'
    }
    // check if number is 0
    else if (increase == 0) {
      // console.log("The number is even");
      console.log(`total: ${original}`, `totalAnterieure: ${newValue}`)
      type = 'even'

    }
    // if number is less than 0
    else {
      // console.log("The number has decreased");

      type = 'decrease'

    }

    return new Variation(type, increase, increasePourcentage);



  }

}
