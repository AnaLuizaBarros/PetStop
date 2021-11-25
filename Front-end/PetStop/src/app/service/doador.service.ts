import { Animal } from './../models/animal.model';
import { Pessoa } from 'src/app/models/pessoa.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class DoadorService {
  constructor(private http: HttpClient) {}

  getDoador(id: number): Observable<Pessoa> {
    return this.http
      .request<Pessoa>(
        'get',
        `https://petstopapi.herokuapp.com/api/doador/buscardoadorporid/${id}`
      )
      .pipe(map((resp) => resp));
  }
  editDoador(data: Pessoa): Observable<any> {
    return this.http
      .request<any>(
        'put',
        `https://petstopapi.herokuapp.com/api/EditarDoador`,
        {
          body: data,
        }
      )
      .pipe(map((resp) => resp));
  }
  listAnimals(id: number): Observable<Animal[]> {
    return this.http
      .request<Animal[]>(
        'get',
        `https://petstopapi.herokuapp.com/api/doador/ListarAnimalPorDoador/${id}`
      )
      .pipe(map((resp) => resp));
  }
  deleteDonor(id: number): Observable<any> {
    return this.http
      .request<any>(
        'delete',
        `https://petstopapi.herokuapp.com/api/doador/ExcluirDoadorPorId/${id}`
      )
      .pipe(map((resp) => resp));
  }
}
