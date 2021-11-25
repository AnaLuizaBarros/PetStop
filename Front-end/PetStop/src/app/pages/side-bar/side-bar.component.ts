import { Pessoa } from './../../models/pessoa.model';
import { EditProfileComponent } from './../edit-profile/edit-profile.component';
import { AdotanteService } from './../../service/adotante.service';
import { DoadorService } from './../../service/doador.service';
import { AlertService } from '@full-fledged/alerts';
import { PetRegisterComponent } from './../pet-register/pet-register.component';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss'],
})
export class SideBarComponent implements OnInit {
  person: Pessoa;
  id;
  tipo;
  name;
  open = false;
  constructor(
    private modal: NgbModal,
    private route: ActivatedRoute,
    private router: Router,
    private alertService: AlertService,
    private doadorService: DoadorService,
    private adotanteService: AdotanteService
  ) {
    var json = JSON.parse(localStorage.getItem('usuario') || '');
    if (json !== '') {
      this.person = json.pessoa;
      this.tipo = json.tipo;
      var split = this.person.nome.split(' ');
      this.name = split[1] ? split[1] : split[0];
    } else {
      this.alertService.danger('Você não tem permissãao! Faça o login.');
      this.router.navigate(['/home']);
    }
  }

  ngOnInit(): void {}

  openMobile() {
    this.open = !this.open;
  }
  petRegister() {
    this.open ? (this.open = !this.open) : false;
    var modalRef = this.modal.open(PetRegisterComponent, { centered: true });
    modalRef.componentInstance.id_doador = this.person.id_doador;
  }
  editProfile() {
    this.open ? (this.open = !this.open) : false;
    this.modal.open(EditProfileComponent, { centered: true });
  }

  excluirPerfil() {
    if (this.tipo === 1) {
      this.adotanteService
        .deleteAdotante(this.person.id_adotante)
        .pipe()
        .subscribe(
          (res) => {
            this.alertService.success('Perfil excluido com sucesso!');
            this.router.navigate['/home'];
          },
          (err) => {
            this.alertService.danger('Houve um erro!');
          }
        );
    } else {
      this.doadorService
        .deleteDonor(this.person.id_doador)
        .pipe()
        .subscribe(
          (res) => {
            this.alertService.success('Perfil excluido com sucesso!');
            this.router.navigate['/home'];
          },
          (err) => {
            this.alertService.danger('Houve um erro!');
          }
        );
    }
  }
  sair() {
    this.alertService.success('Logout realizado com sucesso!');
    this.router.navigate(['/home']);
    localStorage.removeItem('usuario');
    localStorage.clear();
  }
}
