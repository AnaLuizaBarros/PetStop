import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Pessoa } from '../models/pessoa.model';
import { CadastroService } from '../service/cadastro.service';
import { CepService } from '../service/cep.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.adotante.component.html',
  styleUrls: ['./cadastro.adotante.component.scss']
})
export class CadastroAdotanteComponent implements OnInit {
  formCadastro!: FormGroup;
  regexCPF = /([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})/;
  regexEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  option: string;

  constructor(
    private formBuilder: FormBuilder,
    private cadastroService: CadastroService,
    private cepsService: CepService,
    private router: Router, 
  ) {
  }

  ngOnInit() {
    this.createFormAdotante(new Pessoa());
    console.log(this.formCadastro.value);
  }

  /* getOption(opcao) {
    console.log(opcao);
    this.option = opcao;
  } */

  /* createForm() {
    if (this.option == 'adotante') {
      console.log(this.option);
      this.createFormAdotante(new Pessoa());
    }
    if (this.option == 'doador') {
      console.log(this.option);
      this.createFormDoador(new Pessoa());
    }   
  } */

  createFormAdotante(pessoa: Pessoa) {
    console.log('createFormAdotante');
    console.log(pessoa);
    this.formCadastro = this.formBuilder.group({
      id_adotante: [pessoa.id_adotante],
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
      dataNascimento: [pessoa.dataNascimento]
    });
  }
  
  onSubmit() {
    console.log(this.formCadastro.value);
    this.cadastro();
    this.formCadastro.reset(new Pessoa());
  }

  resetar() {
    this.formCadastro.reset();
  }

  homeReturn() {
    this.router.navigate(['/#']);
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

  cadastro() {
    console.log(this.formCadastro.valid);
    if (this.formCadastro.valid) {
      console.log(this.formCadastro.value);
      this.cadastroService
        .salvarAdotante(this.formCadastro.value)
        .pipe()
        .subscribe((res) => {});
    }
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

        /* idade: [pessoa.idade],
      confirmarEmail: [pessoa.email, Validators.pattern(this.regexEmail)],
      confirmarSenha: [pessoa.senha]
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
      alergia: this.formBuilder.group({
        alergia_ID: null,
        nome: null,
      }) */

}
