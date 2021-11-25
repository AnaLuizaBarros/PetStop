import { Pessoa } from 'src/app/models/pessoa.model';

export class Animal {
  id_animal?: number;
  nome: string;
  imagens: imagens[];
  id_especie?: number;
  nome_especie?: string;
  id_doador: number;
  id_raca: number;
  nome_raca?: string;
  id_porte: number;
  nome_porte?: string;
  adotado?: boolean;
  doador?: Pessoa;

  constructor(obj?: Animal) {
    this.id_animal = (obj && obj.id_animal) || 0;
    this.nome = (obj && obj.nome) || '';
    this.imagens = (obj && obj.imagens) || [];
    this.id_especie = (obj && obj.id_especie) || 0;
    this.nome_especie = (obj && obj.nome_especie) || '';
    this.id_doador = (obj && obj.id_doador) || 0;
    this.id_raca = (obj && obj.id_raca) || 0;
    this.id_porte = (obj && obj.id_porte) || 0;
    this.nome_porte = (obj && obj.nome_porte) || '';
    this.id_doador = (obj && obj.id_doador) || 0;
    this.doador = obj && obj.doador;
    this.adotado = (obj && obj.adotado) || false;
  }
}

export interface imagens {
  id_imagem?: number;
  imagem: string;
  id_animal?: number;
}
