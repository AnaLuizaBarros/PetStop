import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Raca } from '../models/raca.model';

@Injectable()
export class RacaService {
  constructor(private http: HttpClient) {}

  retrieveRacaByEspecie(id: number): Observable<Raca[]> {
    return this.http
      .request<Raca[]>(
        'get',
        `https://petstopapi.herokuapp.com/api/raca/BuscarTodasRacasPorEspeciePorId/${id}`
      )
      .pipe(map((resp) => resp));
  }
  retrieveRacaById(id: number): Observable<Raca> {
    return this.http
      .request<Raca>(
        'get',
        `https://petstopapi.herokuapp.com/api/raca/BuscarRacaPorId/${id}`
      )
      .pipe(map((resp) => resp));
  }
  retrieveRacas(): Observable<Raca[]> {
    return this.http
      .request<Raca[]>(
        'get',
        `https://petstopapi.herokuapp.com/api/raca/BuscarTodasRacas`
      )
      .pipe(map((resp) => resp));
  }
}
