export class Pessoa {
  id_doador: number;
  nome: string;
  senha: string;
  email: string;
  cpf: string;
  telefone: string;
  rua: string;
  numero: string;
  complemento: string;
  bairro: string;
  cidade: string;
  cep: string;
  estado: string;
  dataNascimento: Date;
  idade?: number; 

  constructor(obj?: Pessoa) {
    this.idade = (obj && obj.idade) || 0;
    this.bairro = (obj && obj.bairro) || '';
    this.cep = (obj && obj.cep) || '';
    this.cidade = (obj && obj.cidade) || '';
    this.complemento = (obj && obj.complemento) || '';
    this.cpf = (obj && obj.cpf) || '';
    this.dataNascimento = (obj && obj.dataNascimento) || new Date();
    this.email = (obj && obj.email) || '';
    this.estado = (obj && obj.estado) || '';
    this.id_doador = (obj && obj.id_doador) || 0;
    this.nome = (obj && obj.nome) || '';
    this.numero = (obj && obj.numero) || '';
    this.rua = (obj && obj.rua) || '';
    this.senha = (obj && obj.senha) || '';
    this.telefone = (obj && obj.telefone) || '';
  }
}
