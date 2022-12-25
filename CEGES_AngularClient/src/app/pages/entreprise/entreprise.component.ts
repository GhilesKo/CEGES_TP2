import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Observer, Subscription } from 'rxjs';
import Periode from 'src/app/dtos/responses/Periode';
import { DataService } from 'src/app/services/data.service';
import { lastValueFrom } from 'rxjs';
import Entreprise from 'src/app/dtos/requests/Entreprise';
@Component({
  selector: 'app-entreprise',
  templateUrl: './entreprise.component.html',
  styleUrls: ['./entreprise.component.css']
})
export class EntrepriseComponent implements OnInit {

  private routeSub?: Subscription;

  public entreprise?: Entreprise;
  periodes?: Record<string, Periode[]>


  constructor(private router: Router, private route: ActivatedRoute, public dataService: DataService) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(
      params => {

        setTimeout(() => {
            this.fetchEntrepriseInfo(params['id'])
            this.fetchPeriodes(params['id'])
        }, 0);

      },);



  }

  private fetchEntrepriseInfo(entrepriseId: number) {
    if (!entrepriseId) return
    this.dataService.getEntrepriseInfo(entrepriseId).subscribe(
      res => {
        this.entreprise = res;
      },
      err => console.log(err),
      () => console.log()
    )
  }
  private fetchPeriodes(entrepriseId: number) {
    if (!entrepriseId) return
    this.dataService.getPeriodes(entrepriseId).subscribe(
      res => {
        this.periodes = this.groupBy(res, i => i.nom.split(' ')[1]);
      },
      err => console.log(err),
      () => console.log()
    )
  }

  private groupBy = <T, K extends keyof any>(arr: T[], key: (i: T) => K) =>
    arr.reduce((groups, item) => {
      (groups[key(item)] ||= []).push(item);
      return groups;
    }, {} as Record<K, T[]>);


  private ngOnDestroy() {
    this.routeSub?.unsubscribe();
  }
}
