import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Entreprise from '../dtos/requests/Entreprise';
import EntrepriseDetails from '../dtos/responses/EntrepriseDetails';
import EntrepriseSommaire from '../dtos/responses/EntrepriseSommaire';
import EntrepriseSommaireAvecVariations from '../dtos/responses/EntrepriseSommaireAvecVariations';
import Equipement from '../dtos/responses/Equipement';
import EquipementDetailsAvecVariation from '../dtos/responses/EquipementDetailsAvecVariation';
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


  getStatistiqueSommaire(entrepriseId: number, periodeId: number, variation: boolean, dateOptions: string | null) {
    return this.http.get<EntrepriseSommaire | EntrepriseSommaireAvecVariations>('/analyse/sommaire', {
      params: {
        entrepriseId: entrepriseId,
        periodeId: periodeId,
        avecVariation: variation,
        dateOption: dateOptions ? dateOptions : ''
      },
    });
  }

  getStatistiqueDetails(entrepriseId: number, periodeId: number, variation: boolean, dateOptions?: string) {
    return this.http.get<EntrepriseDetails | EquipementDetailsAvecVariation>('/analyse/details', {
      params: {
        entrepriseId: entrepriseId,
        periodeId: periodeId,
        avecVariation: variation,
        dateOption: dateOptions ? dateOptions : ''

      },
    });
  }

}
