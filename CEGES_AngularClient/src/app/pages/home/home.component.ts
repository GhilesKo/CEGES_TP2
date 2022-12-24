import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import Entreprise from 'src/app/dtos/requests/Entreprise';
import { AuthService } from 'src/app/services/auth.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public entreprises?: Entreprise[];

  constructor(private authService: AuthService, private dataService: DataService) { }

  ngOnInit() {

    this.dataService.getEntreprises().subscribe(
      res => this.entreprises = res,
      err => console.log(err),
      () => console.log('/analyse/entreprises completed')
    )

  }
  getClaims() {
    this.authService.getClaims().subscribe();
  }
}
