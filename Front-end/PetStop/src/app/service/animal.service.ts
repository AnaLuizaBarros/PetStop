import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Animal } from '../models/animal.model';

@Injectable()
export class AnimalService {
  constructor(private http: HttpClient) {}
  registerAnimal(data: Animal): Observable<any> {
    return this.http
      .request<any>('post', `https://petstopapi.herokuapp.com/api/animal`, {
        body: data,
      })
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
}
