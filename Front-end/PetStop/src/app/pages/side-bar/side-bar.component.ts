import { PetRegisterComponent } from './../pet-register/pet-register.component';
import { Component, OnInit } from '@angular/core';
import { Pessoa } from 'src/app/models/pessoa.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss'],
})
export class SideBarComponent implements OnInit {
  person;
  tipo;
  name;
  open = false;
  constructor(
    private modal: NgbModal,
    private route: ActivatedRoute,
    private router: Router
  ) {
    var json = JSON.parse(localStorage.getItem('usuario') || '');
    if (json !== '') {
      this.person = json.pessoa;
      this.tipo = json.tipo;
      var split = this.person.nome.split(' ');
      this.name = split[1] ? split[1] : split[0];
    } else {
      this.router.navigate(['/home']);
    }
  }

  ngOnInit(): void {}
  petSearch() {
    this.router.navigate(['pesquisa']);
  }
  openMobile() {
    this.open = !this.open;
  }
  petRegister() {
    this.modal.open(PetRegisterComponent, { centered: true });
  }
}
