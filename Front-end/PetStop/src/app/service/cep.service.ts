import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CepService {
  constructor(private httpClient: HttpClient) {}

  buscar(cep: String) {
    console.log(cep);
    return this.httpClient.get(`https://viacep.com.br/ws/${cep}/json/`);
  }
}
