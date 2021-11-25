import { Especie } from './../models/especie.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class EspecieService {
  constructor(private http: HttpClient) {}

  retrieveEspecies(): Observable<Especie[]> {
    return this.http
      .request<Especie[]>(
        'get',
        `https://petstopapi.herokuapp.com/api/especie/BuscarTodasEspecies`
      )
      .pipe(map((resp) => resp));
  }
  retrieveEspecieById(id: number): Observable<Especie> {
    return this.http
      .request<Especie>(
        'get',
        `https://petstopapi.herokuapp.com/api/especie/BuscarEspeciePorId/${id}`
      )
      .pipe(map((resp) => resp));
  }
}
