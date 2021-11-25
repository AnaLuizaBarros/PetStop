import { Animal } from './../models/animal.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AnimalService {
  constructor(private http: HttpClient) {}
  registerAnimal(data: Animal): Observable<any> {
    return this.http
      .request<any>(
        'post',
        `https://petstopapi.herokuapp.com/api/animal/SalvarAnimal`,
        {
          body: data,
        }
      )
      .pipe(map((resp) => resp));
  }
  retrieveImages(id: number): Observable<any> {
    return this.http
      .request<any>(
        'get',
        `https://petstopapi.herokuapp.com/api/animal/${id}/imagens`
      )
      .pipe(map((resp) => resp));
  }
  registerImages(id: number): Observable<any> {
    return this.http
      .request<any>(
        'get',
        `https://petstopapi.herokuapp.com/api/animal/${id}/imagens`
      )
      .pipe(map((resp) => resp));
  }
  retrieveFilter(id: number): Observable<Animal[]> {
    return this.http
      .request<Animal[]>(
        'get',
        `https://petstopapi.herokuapp.com/api/doador/FiltrarAnimais?id_raca=${id}&id_porte=0`
      )
      .pipe(map((resp) => resp));
  }
  editAnimal(data: Animal): Observable<any> {
    return this.http
      .request<any>(
        'put',
        `https://petstopapi.herokuapp.com/api/animal/EditarAnimal`,
        {
          body: data,
        }
      )
      .pipe(map((resp) => resp));
  }
  deleteAnimal(id: number): Observable<any> {
    return this.http
      .request<any>(
        'delete',
        `https://petstopapi.herokuapp.com/api/animal/DeletarAnimal?id_animal=${id}`
      )
      .pipe(map((resp) => resp));
  }
}
