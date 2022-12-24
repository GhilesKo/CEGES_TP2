import { Component, Input, OnInit } from '@angular/core';
import Periode from 'src/app/dtos/responses/Periode';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  @Input()   periodes?: Record<string, Periode[]>
  constructor() { }

  ngOnInit() {
  }

}
