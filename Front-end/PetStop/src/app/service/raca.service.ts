import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Login } from '../models/login.model';
import { BaseResponse } from '../models/baseResponse.model';
import { Pessoa } from '../models/pessoa.model';
import { Raca } from '../models/raca.model';

@Injectable()
export class RacaService {
  constructor(private http: HttpClient) {}

  retrieveRaca(): Observable<Raca[]> {
    return this.http
      .request<Raca[]>(
        'get',
        `https://petstopapi.herokuapp.com/api/raca/especie/1`
      )
      .pipe(map((resp) => resp));
  }
}
