import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { cadastrarDoador, salvarAdotante } from '../models/cadastro.model';

@Injectable()
export class CadastroService {
  constructor(private http: HttpClient) {}

  cadastrarDoador(data: cadastrarDoador): Observable<any> {
    console.log(data);
    return this.http
      .request<any>('post', `https://petstopapi.herokuapp.com/api/doador/CadastrarDoador`, {
        body: data,
      })
      .pipe(map((resp) => resp));
  }

  salvarAdotante(data: salvarAdotante): Observable<any> {
    console.log(data);
    return this.http
      .request<any>('post', `https://petstopapi.herokuapp.com/api/adotante/SalvarAdotante`, {
        body: data,
      })
      .pipe(map((resp) => resp));
  }

}
