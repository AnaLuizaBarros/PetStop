import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Login } from '../models/login.model';
import { BaseResponse } from '../models/baseResponse.model';
import { Pessoa } from '../models/pessoa.model';

@Injectable()
export class LoginService {
  constructor(private http: HttpClient) {}

  userLogin(data: Login): Observable<Pessoa> {
    return this.http
      .request<Pessoa>('post', `https://petstopapi.herokuapp.com/api/login`, {
        body: data,
      })
      .pipe(map((resp) => resp));
  }
}
