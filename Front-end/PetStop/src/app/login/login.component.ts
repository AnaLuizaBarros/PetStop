import { LoginService } from './../service/login.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from '../models/login.model';
import { Md5 } from 'ts-md5/dist/md5';
import { Pessoa } from '../models/pessoa.model';
import { ActivatedRoute, ActivationEnd, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import {
  AuthService,
  FacebookLoginProvider,
  GoogleLoginProvider,
} from 'angular-6-social-login';
import { AlertService } from '@full-fledged/alerts';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  person: Pessoa;
  md5 = new Md5();
  constructor(
    private fb: FormBuilder,
    private loginSerive: LoginService,
    private route: Router,
    public activeModal: NgbActiveModal,
    private alertService: AlertService // private socialAuthService: AuthService
  ) {
    this.loginForm = this.fb.group({
      tipo: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email]],
      senha: [null, [Validators.required]],
    });
  }

  ngOnInit(): void {}

  login() {
    this.md5 = new Md5();
    let hash = this.md5.appendStr(this.loginForm.controls['senha'].value).end();
    let body: Login = {
      tipo: this.loginForm.controls['tipo'].value,
      email: this.loginForm.controls['email'].value,
      senha: hash.toString(),
    };
    this.loginSerive
      .userLogin(body)
      .pipe()
      .subscribe(
        (res) => {
          if (
            (this.loginForm.controls['tipo'].value == 0 &&
              res.id_doador != 0) ||
            (this.loginForm.controls['tipo'].value == 1 && res.id_adotante != 0)
          ) {
            this.alertService.success('Login realizado!');
            this.person = res;
            localStorage.setItem(
              'usuario',
              JSON.stringify({
                pessoa: this.person,
                tipo: this.loginForm.controls['tipo'].value,
              })
            );
            this.activeModal.close('Close');
            this.route.navigate(['dashboard']);
          } else {
            this.alertService.danger('Verifique os dados e tente novamente!');
          }
        },
        (err) => {
          console.log('faz algo carias');
        }
      );
  }
  loginSocial(plataform: string) {
    let socialPlataform: string;
    if (plataform === 'facebook') {
      socialPlataform = FacebookLoginProvider.PROVIDER_ID;
    } else if (plataform === 'google') {
      socialPlataform = GoogleLoginProvider.PROVIDER_ID;
    }
    /*   this.socialAuthService
      .signIn(GoogleLoginProvider.PROVIDER_ID)
      .then((userData) => {});*/
  }
}
