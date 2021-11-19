import { Especie } from './../models/especie.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Login } from '../models/login.model';
import { BaseResponse } from '../models/baseResponse.model';
import { Pessoa } from '../models/pessoa.model';
import { Raca } from '../models/raca.model';

@Injectable()
export class EspecieService {
  constructor(private http: HttpClient) {}

  retrieveEspecies(): Observable<Especie[]> {
    return this.http
      .request<Especie[]>('get', `https://petstopapi.herokuapp.com/api/especie`)
      .pipe(map((resp) => resp));
  }
}
