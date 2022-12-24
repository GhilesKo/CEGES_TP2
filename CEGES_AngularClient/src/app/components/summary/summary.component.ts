import { Component, ViewChild, Input, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import Periode from 'src/app/dtos/responses/Periode';
import { ApexPlotOptions, ApexTitleSubtitle, ChartComponent } from "ng-apexcharts";
import {
  ApexNonAxisChartSeries,
  ApexResponsive,
  ApexChart
} from "ng-apexcharts";
import { lastValueFrom } from 'rxjs';
import { DialogService } from 'src/app/services/dialog.service';
import EntrepriseSommaire from 'src/app/dtos/responses/EntrepriseSommaire';
import EntrepriseSommaireAvecVariations from 'src/app/dtos/responses/EntrepriseSommaireAvecVariations';
@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

  @Input() periodes?: Record<string, Periode[]>
  @Input() entrepriseId?: number;


  avecVariation = false;

  vartiationOptions: any[] = [{ value: 'same', text: 'mois précédent', }, { value: 'last', text: 'même mois de l’année précédente' }]
  selectedOption: string = 'same';

  selectedPeriode?: Periode;

  @ViewChild("chart") chart?: ChartComponent;
  public chartOptions?: Partial<ChartOptions>;


  constructor(private dataService: DataService, public dialogService: DialogService) { }


  ngOnInit() { }



  openDialog() {

    const callback = (selectedPeriode: Periode) => {
      this.fetchStatistiqueSommaire(selectedPeriode)
      this.selectedPeriode = selectedPeriode;
    }

    this.dialogService.openPeriodesDialog(this.periodes!, this.avecVariation, callback);

  }


  fetchStatistiqueSommaire(selectedPeriode: Periode) {


    // const avecVariation = selectedDates.length < 2 ? false: true;


    // console.log(this.entrepriseId,selectedPeriode.nom,this.avecVariation,this.selectedOption)
    try {

      this.dataService.getStatistiqueSommaire(this.entrepriseId!, selectedPeriode.id, this.avecVariation, this.selectedOption!).subscribe(
        result  =>{
          const data = result.groupes.map((g: any) => g.total);
          // console.log(data)
          const noms = result.groupes.map((g: any) => g.nom);
          // console.log(noms)
          this.chartOptions = {
    
            series: [...data],
            chart: {
              width: 400,
              type: "pie"
            },
            labels: [...noms],
    
          };
        },
        err => console.log(err),
        () => { 'completed' },
      )
      // const result = await lastValueFrom(this.dataService.getStatistiqueSommaire(this.entrepriseId!, selectedPeriode.id, this.avecVariation, this.selectedOption!));
      // console.log(result)
      // return result;

    } catch (error) {
      console.log(error)

    }





  }

}


export type ChartOptions = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  responsive: ApexResponsive[];
  labels: any;
  plotOptions: ApexPlotOptions
};
