export class Pessoa {
  idade?: number;
  bairro: string;
  cep: number;
  cidade: string;
  complemento: string;
  cpf: number;
  dataNascimento: Date;
  email: string;
  estado: string;
  id_doador: number;
  id_adotante: number;
  nome: string;
  numero: number;
  rua: string;
  senha: string;
  telefone: number;

  constructor(obj?: Pessoa) {
    this.idade = (obj && obj.idade) || 0;
    this.bairro = (obj && obj.bairro) || '';
    this.cep = (obj && obj.cep) || 0;
    this.cidade = (obj && obj.cidade) || '';
    this.complemento = (obj && obj.complemento) || '';
    this.cpf = (obj && obj.cpf) || 0;
    this.dataNascimento = (obj && obj.dataNascimento) || new Date();
    this.email = (obj && obj.email) || '';
    this.estado = (obj && obj.estado) || '';
    this.id_doador = (obj && obj.id_doador) || 0;
    this.id_adotante = (obj && obj.id_adotante) || 0;
    this.nome = (obj && obj.nome) || '';
    this.numero = (obj && obj.numero) || 0;
    this.rua = (obj && obj.rua) || '';
    this.senha = (obj && obj.senha) || '';
    this.telefone = (obj && obj.telefone) || 0;
  }
}
