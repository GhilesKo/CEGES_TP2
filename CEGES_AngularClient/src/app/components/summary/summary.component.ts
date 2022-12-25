import { Component, ViewChild, Input, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import Periode from 'src/app/dtos/responses/Periode';
import { ApexPlotOptions, ChartComponent } from "ng-apexcharts";
import {
  ApexNonAxisChartSeries,
  ApexResponsive,
  ApexChart
} from "ng-apexcharts";
import { DialogService } from 'src/app/services/dialog.service';
import Entreprise from 'src/app/dtos/requests/Entreprise';
import EntrepriseSommaire from 'src/app/dtos/responses/EntrepriseSommaire';
import EntrepriseSommaireAvecVariations from 'src/app/dtos/responses/EntrepriseSommaireAvecVariations';
import GroupeSommaire from 'src/app/dtos/responses/GroupeSommaire';
import Variation from 'src/app/models/variation';
@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {
  @Input() periodes?: Record<string, Periode[]>
  @Input() entreprise?: Entreprise;

  avecVariation = false;

  selectedPeriode?: Periode;

  vartiationOptions: any[] = [{ value: 'same', text: 'mois précédent', }, { value: 'last', text: 'même mois de l’année précédente' }]
  selectedOption: string = 'same';


  @ViewChild("chart") chart?: ChartComponent;
  public chartOptions?: Partial<ChartOptions>;

  public total?: number;

  public variation?: Variation;

  constructor(private dataService: DataService, public dialogService: DialogService) { }


  ngOnInit() { }



  openDialog() {
    const callback = (selectedPeriode: Periode) => {
      this.fetchStatistiqueSommaire(selectedPeriode)
    }
    this.dialogService.openPeriodesDialog(this.periodes!, this.avecVariation, callback);

  }


  fetchStatistiqueSommaire(selectedPeriode: Periode) {
    this.dataService.getStatistiqueSommaire(this.entreprise?.id!, selectedPeriode.id, this.avecVariation, this.selectedOption).subscribe(
      (result) => {
        this.selectedPeriode = selectedPeriode;

        if (this.avecVariation) {
          this.variation = this.calculateVariation(result.total, result.totalPeriodeAnterieure)
          console.log(result)

        } else {
          this.variation = undefined;
        }

        this.total = Math.round(result.total);

        const data = result.groupes.map((g: any) => g.total);
        const noms = result.groupes.map((g: any) => g.nom);
        this.chartOptions = {

          series: [...data],
          chart: {
            width: 400,
            type: "pie"
          },
          labels: [...noms],

        };

      },
      err => {
        console.log(err);
        this.dialogService.openErrorDialog(`Aucune periode anterieure à ${selectedPeriode.nom}`)
      },
      () => { 'fetchStatistiqueSommaire completed' },
    )
  }


  calculateVariation(original: number, newValue: number): Variation {
    // % increase = Increase ÷ Original Number × 100.
    console.log(`total: ${original}`, `totalAnterieure: ${newValue}`)
    let type;
    const increase = newValue - original;
    const increasePourcentage = increase / original * 100
    // check if number is greater than 0
    if (increase > 0) {
      console.log("The number has increase");
      type = 'increase'
    }
    // check if number is 0
    else if (increase == 0) {
      console.log("The number is even");
      type = 'even'

    }
    // if number is less than 0
    else {
      console.log("The number has decreased");

      type = 'decrease'

    }

    return new Variation(type, increase, increasePourcentage);



  }
}


export type ChartOptions = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  responsive: ApexResponsive[];
  labels: any;
  plotOptions: ApexPlotOptions
};
