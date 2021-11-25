import { AdotanteService } from './../../service/adotante.service';
import { DoadorService } from './../../service/doador.service';
import { Pessoa } from 'src/app/models/pessoa.model';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AlertService } from '@full-fledged/alerts';
import { Router } from '@angular/router';
import { Md5 } from 'ts-md5';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss'],
})
export class EditProfileComponent implements OnInit {
  loading = true;
  editProfileForm: FormGroup;
  person: Pessoa;
  tipo: number;
  md5;
  constructor(
    public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private router: Router,
    private alertService: AlertService,
    private doadorService: DoadorService,
    private adotanteService: AdotanteService
  ) {
    this.editProfileForm = this.fb.group({
      id_doador: [''],
      id_adotante: [''],
      nome: [''],
      senha: [''],
      email: [''],
      cpf: [''],
      telefone: [''],
      rua: [''],
      numero: [''],
      complemento: [''],
      bairro: [''],
      cidade: [''],
      cep: [''],
      estado: [''],
      dataNascimento: [''],
    });
  }

  ngOnInit(): void {
    var json = JSON.parse(localStorage.getItem('usuario') || '');
    if (json !== '') {
      this.person = json.pessoa;
      this.tipo = json.tipo;
      this.getProfile();
    } else {
      this.alertService.danger('Você não tem permissãao! Faça o login.');
      this.router.navigate(['/home']);
    }
  }

  getProfile() {
    if (this.tipo == 0) {
      this.doadorService
        .getDoador(this.person.id_doador)
        .pipe()
        .subscribe(
          (res) => {
            this.refreshForms(res);
          },
          (err) => {
            this.alertService.danger('Erro ao retornar dados!');
          }
        );
    } else {
      this.adotanteService
        .getAdotante(this.person.id_adotante)
        .pipe()
        .subscribe(
          (res) => {
            this.refreshForms(res);
          },
          (err) => {
            this.alertService.danger('Erro ao retornar dados!');
          }
        );
    }
  }

  refreshForms(profile: Pessoa) {
    this.loading = false;
    Object.keys(this.editProfileForm.controls).forEach((name) => {
      this.editProfileForm.controls[name].patchValue(profile[name]);
    });
  }

  editProfile() {
    const data: Pessoa = {
      ...this.editProfileForm.value,
    };
    this.loading = true;
    if (this.tipo == 0) {
      this.doadorService
        .editDoador(data)
        .pipe()
        .subscribe(
          (res) => {
            this.alertService.success('Dados alterados!');
            this.loading = false;
            this.activeModal.close();
          },
          (err) => {
            this.alertService.danger('Erro ao atualizar os dados!');
          }
        );
    } else {
      this.adotanteService
        .editAdotante(data)
        .pipe()
        .subscribe(
          (res) => {
            this.alertService.success('Dados alterados!');
            this.loading = false;
            this.activeModal.close();
          },
          (err) => {
            this.alertService.danger('Erro ao atualizar os dados!');
          }
        );
    }
  }
}
