import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Md5 } from 'ts-md5';
import { Pessoa } from '../models/pessoa.model';
import { CadastroService } from '../service/cadastro.service';
import { CepService } from '../service/cep.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.doador.component.html',
  styleUrls: ['./cadastro.doador.component.scss']
})
export class CadastroDoadorComponent implements OnInit {
  formCadastro!: FormGroup;
  regexCPF = /([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})/;
  regexEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  option: string;
  md5 = new Md5();

  constructor(
    private formBuilder: FormBuilder,
    private cadastroService: CadastroService,
    private cepsService: CepService,
    private router: Router, 
  ) {
  }

  ngOnInit() {
    this.createFormDoador(new Pessoa());
  }

  createFormDoador(pessoa: Pessoa) {
    this.formCadastro = this.formBuilder.group({
      id_doador: [pessoa.id_doador],
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
    let hash = this.md5.appendStr(this.formCadastro.controls['senha'].value).end();
    hash = hash.toString(),
    this.formCadastro.get('senha')?.setValue(hash);
    this.cadastro();
    this.formCadastro.reset(new Pessoa());
  }

  resetar() {
    this.formCadastro.reset();
  }

  homeReturn() {
    this.router.navigate(['/cadastro']);
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
  }

  cadastro() {
    if (this.formCadastro.valid) {
      this.cadastroService
        .cadastrarDoador(this.formCadastro.value)
        .pipe()
        .subscribe((res) => {});
    }
  }

}
