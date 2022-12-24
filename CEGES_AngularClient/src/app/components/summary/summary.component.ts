import { Component, ViewChild, Input, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import Periode from 'src/app/dtos/responses/Periode';
import { ChartComponent } from "ng-apexcharts";
import {
  ApexNonAxisChartSeries,
  ApexResponsive,
  ApexChart
} from "ng-apexcharts";
import { lastValueFrom } from 'rxjs';
import { DialogService } from 'src/app/services/dialog.service';
@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

  @Input() periodes?: Record<string, Periode[]>
  @Input() entrepriseId?: number;


  avecVariation = false;
  periode?: Periode;
  periodeAnterieur?: Periode;

  @ViewChild("chart") chart?: ChartComponent;
  public chartOptions?: Partial<ChartOptions>;


  constructor(private dataService: DataService, public dialogService: DialogService) { }


  ngOnInit() { }

  getStatistiqueSommaire() {
    this.dataService.getStatistiqueSommaire(1, 1, false, 2).subscribe(
      res => console.log(res),
      err => console.log(err),
      () => console.log()
    )
  }

  openPeriodesDialog() {

    const callback = (pickedPeriode:any) => {
      this.periode = pickedPeriode;
      this.fetchStatistiqueSommaire()
    }

    this.dialogService.openPeriodesDialog(this.periodes!, this.avecVariation, callback);
   
  }


  async fetchStatistiqueSommaire(): Promise<any> {

    if (!this.avecVariation) {
      if (this.periode) {
        try {
          const result: any = await lastValueFrom(this.dataService.getStatistiqueSommaire(this.entrepriseId!, this.periode?.id, this.avecVariation));
          // console.log(result)
          const data = result.groupes.map((g: any) => g.total);
          // console.log(data)
          const noms = result.groupes.map((g: any) => g.nom);
          // console.log(noms)
          this.chartOptions = {

            series: [...data],
            chart: {
              toolbar: {
                show: true
              },
              width: 380,
              type: "pie"
            },
            labels: [...noms],

          };
          return result;
        } catch (error) {
          console.log(error)
        }
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

}


export type ChartOptions = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  responsive: ApexResponsive[];
  labels: any;
};
