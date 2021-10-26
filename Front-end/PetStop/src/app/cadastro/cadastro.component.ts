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
  regexCPF = /^\d{3}\.\d{3}\.\d{3}\-\d{2}$/;
  regexEmail =
    /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  constructor(
    private formBuilder: FormBuilder,
    private cepsService: CepService
  ) {
    console.log('oi');
  }

  ngOnInit() {
    console.log('ngOnInit');
    this.createForm(new Pessoa());
    console.log(this.formCadastro.value);
  }

  createForm(pessoa: Pessoa) {
    console.log('createForm');
    console.log(pessoa);
    this.formCadastro = this.formBuilder.group({
      pessoa_ID: [pessoa.id_doador],
      nome: [pessoa.nome],
      idade: [pessoa.idade],
      cpf: [pessoa.cpf, Validators.pattern(this.regexCPF)],
      telefone: [pessoa.telefone],
      dt_Nascimento: [pessoa.idade],
      email: [pessoa.email, Validators.pattern(this.regexEmail)],
      confirmarEmail: [pessoa.email, Validators.pattern(this.regexEmail)],
      senha: [pessoa.senha],
      confirmarSenha: [pessoa.senha],
      endereco: this.formBuilder.group({
        endereco_ID: [null],
        rua: [null],
        numero: [null],
        complemento: [null],
        bairro: [null],
        cidade: [null],
        cep: [null],
        estado: [null],
        sigla: [null],
      }),
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
    if (cep != null && cep !== '') {
      this.cepsService.buscar(cep).subscribe((dados) => this.populaForm(dados));
    }
  }

  populaForm(dados: any) {
    this.formCadastro.patchValue({
      rua: dados.logradouro,
      bairro: dados.bairro,
      cidade: dados.localidade,
      //estado: dados.uf
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
