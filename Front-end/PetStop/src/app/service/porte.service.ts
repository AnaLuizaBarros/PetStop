import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Porte } from '../models/porte.model';

@Injectable()
export class PorteService {
  constructor(private http: HttpClient) {}

  retrievePorte(): Observable<Porte[]> {
    return this.http
      .request<Porte[]>(
        'get',
        `https://petstopapi.herokuapp.com/api/porte/BuscarTodosPortes`
      )
      .pipe(map((resp) => resp));
  }
}
