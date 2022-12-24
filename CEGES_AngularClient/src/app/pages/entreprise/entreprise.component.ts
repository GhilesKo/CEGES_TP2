import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Observer, Subscription } from 'rxjs';
import Entreprise from 'src/app/dtos/requests/Entreprise';
import Periode from 'src/app/dtos/responses/Periode';
import { DataService } from 'src/app/services/data.service';
import { lastValueFrom } from 'rxjs';
@Component({
  selector: 'app-entreprise',
  templateUrl: './entreprise.component.html',
  styleUrls: ['./entreprise.component.css']
})
export class EntrepriseComponent implements OnInit {

  private routeSub?: Subscription;

  public entrepriseId?: number;

  periodes?: Record<string, Periode[]>


  constructor(private router: Router, private route: ActivatedRoute, public dataService: DataService) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(
      params => {
        this.entrepriseId = params['id'];
      },);

    setTimeout(() => {
      this.fetchPeriodes()
    }, 0);

  }

  private fetchPeriodes() {
    if (!this.entrepriseId) return
    this.dataService.getPeriodes(this.entrepriseId).subscribe(
      res => this.periodes = this.groupBy(res, i => i.nom.split(' ')[1]),
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
