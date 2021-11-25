import { Pessoa } from 'src/app/models/pessoa.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AdotanteService {
  constructor(private http: HttpClient) {}
  getAdotante(id: number): Observable<Pessoa> {
    return this.http.request<Pessoa>(
      'get',
      `https://petstopapi.herokuapp.com/api/adotante/BuscarAdotantePorId/${id}`
    );
  }
  editAdotante(data: Pessoa): Observable<any> {
    return this.http.request<any>(
      'put',
      `https://petstopapi.herokuapp.com/api/adotante/editaradotante`,
      {
        body: data,
      }
    );
  }
  adoptAnimal(data: any): Observable<any> {
    return this.http.request<any>(
      'post',
      `https://petstopapi.herokuapp.com/api/adotante/AdotarAnimal`,
      {
        body: data,
      }
    );
  }
  deleteAdotante(id: number): Observable<any> {
    return this.http
      .request<any>(
        'delete',
        `https://petstopapi.herokuapp.com/api/doador/ExcluirDoadorPorId/${id}`
      )
      .pipe(map((resp) => resp));
  }
}
