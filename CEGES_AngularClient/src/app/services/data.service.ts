import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Entreprise from '../dtos/requests/Entreprise';
import Equipement from '../dtos/responses/Equipement';
import Periode from '../dtos/responses/Periode';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }


  getEntreprises() {
    return this.http.get<Entreprise[]>('/analyse/entreprises')
  }

  getPeriodes(entrepriseId: number) {
    return this.http.get<Periode[]>(`/analyse/periodes/${entrepriseId}`)
  }

  getStatistiqueSommaire(entrepriseId: number, periodeId: number, variation: boolean, periodeAnterieurId?: number) {
    return this.http.get('/analyse/sommaire', {
      params: {
        entrepriseId: entrepriseId,
        periodeId: periodeId,
        variation: variation,
        periodeAnterieurId: periodeAnterieurId ? periodeAnterieurId : 0

      },
    });
  }

  getStatistiqueDetails(entrepriseId: number, periodeId: number, variation: boolean, periodeAnterieurId?: number) {
    return this.http.get<any>('/analyse/details', {
      params: {
        entrepriseId: entrepriseId,
        periodeId: periodeId,
        variation: variation,
        periodeAnterieurId: periodeAnterieurId ? periodeAnterieurId : 0

      },
    });
  }

}
