import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Pessoa } from '../models/pessoa.model';
import { CepService } from '../service/cep.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss'],
})
export class CadastroComponent implements OnInit {
  formCadastro!: FormGroup;
  regexCPF = /([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})/;
  regexEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  constructor(
    private formBuilder: FormBuilder,
    private cepsService: CepService
  ) {
  }

  ngOnInit() {
    this.createForm(new Pessoa());
    console.log(this.formCadastro.value);
  }

  createForm(pessoa: Pessoa) {
    console.log(pessoa);
    this.formCadastro = this.formBuilder.group({
      id_pessoa: [pessoa.id_doador],

      nome: [pessoa.nome],
      senha: [pessoa.senha],
      email: [pessoa.email, Validators.pattern(this.regexEmail)],
      cpf: [pessoa.cpf, Validators.pattern(this.regexCPF)],
      telefone: [pessoa.telefone],
      rua: [pessoa.rua],
      numero: [pessoa.numero],
      complemento: [pessoa.complemento],
      bairro: [pessoa.bairro],
      cidade: [pessoa.cidade],
      cep: [pessoa.cep],
      estado: [pessoa.estado],
      dataNascimento: [pessoa.dataNascimento],

      idade: [pessoa.idade],
      confirmarEmail: [pessoa.email, Validators.pattern(this.regexEmail)],
      confirmarSenha: [pessoa.senha]
      /* endereco: this.formBuilder.group({
        endereco_ID: [null],
        rua: [null],
        numero: [null],
        complemento: [null],
        bairro: [null],
        cidade: [null],
        cep: [null],
        estado: [null],
        sigla: [null],
      }), */
      /* alergia: this.formBuilder.group({
        alergia_ID: null,
        nome: null,
      }) */
    });
  }

  onSubmit() {
    console.log(this.formCadastro.value);
    this.formCadastro.reset(new Pessoa());
  }

  resetar() {
    this.formCadastro.reset();
  }

  consultaCEP() {
    const cep = this.formCadastro.get('cep')?.value;
    if (cep != null && cep != '') {
      this.cepsService.buscar(cep).subscribe((dados) => this.populaForm(dados));
    }
  }

  populaForm(dados: any) {
    this.formCadastro.patchValue({
      rua: dados.logradouro,
      bairro: dados.bairro,
      cidade: dados.localidade,
      estado: dados.uf
    });
    //console.log(this.formCadastro.value);
  }

  /* static equals(otherField: string) {
    const validator = (formControl: FormControl) => {
      if (otherField == null) {
        throw new Error('É necessário informar um campo.')
      }
      //const field = formControl.
    };
    return validator;
  } */
}
