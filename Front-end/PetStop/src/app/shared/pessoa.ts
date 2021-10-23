export class Pessoa {
  pessoa_ID: number = 0;
  nome: string = '';
  idade: number = 0;
  cpf: string = '';
  telefone: string = '';
  dt_Nascimento: string = '';
  email: string = '';
  confirmarEmail: string = '';
  senha: string = '';
  confirmarSenha: string = '';
  endereco: any = {
    endereco_ID: null,
    rua: null,
    numero: null,
    complemento: null,
    bairro: null,
    cidade: null,
    cep: null,
    estado: null,
    sigla: null,
  };
  /* alergia: any = {
    alergia_ID: null,
    nome: null,
  }; */
}