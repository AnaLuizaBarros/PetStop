import { LoginService } from './../service/login.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from '../models/login.model';
import { Md5 } from 'ts-md5/dist/md5';
import { Pessoa } from '../models/pessoa.model';
import { ActivatedRoute, ActivationEnd, Router } from '@angular/router';
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
    private route: Router
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
          this.person = res;
          localStorage.setItem(
            'usuario',
            JSON.stringify({ pessoa: this.person })
          );
          this.route.navigate(['dashboard']);
        },
        (err) => {
          console.log('faz algo carias');
        }
      );
  }
}
