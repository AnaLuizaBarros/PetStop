import { AnimalService } from 'src/app/service/animal.service';
import { AlertService } from '@full-fledged/alerts';
import { DoadorService } from './../../service/doador.service';
import { Animal } from './../../models/animal.model';
import { Component, OnInit } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PetRegisterComponent } from '../pet-register/pet-register.component';
import { DomSanitizer } from '@angular/platform-browser';
@Component({
  selector: 'app-donor-animals',
  templateUrl: './donor-animals.component.html',
  styleUrls: ['./donor-animals.component.scss'],
})
export class DonorAnimalsComponent implements OnInit {
  idDoador: number;
  donorAnimals: Animal[] = [];
  loading = true;
  constructor(
    private doadorService: DoadorService,
    private alertService: AlertService,
    private modal: NgbModal,
    private animalService: AnimalService
  ) {
    var json = JSON.parse(localStorage.getItem('usuario') || '');
    var pessoa = json.pessoa;
    this.idDoador = pessoa.id_doador;
  }

  ngOnInit(): void {
    this.getAnimals();
  }

  getAnimals() {
    this.doadorService
      .listAnimals(this.idDoador)
      .pipe()
      .subscribe(
        (res) => {
          this.donorAnimals = res;
          this.loading = false;
        },
        (err) => {
          this.alertService.danger('Erro ao retornar os animais!');
        }
      );
  }
  petEdit(animal: Animal) {
    const modalRef = this.modal.open(PetRegisterComponent, { centered: true });
    modalRef.componentInstance.editAnimal = animal;
    modalRef.result.then((result) => {
      if (result) {
        this.loading = true;
        this.getAnimals();
      }
    });
  }
  deleteAnimal(id: any, nome: string) {
    if (
      window.confirm('Você realmente deseja excluir o animal: ' + nome + ' ?')
    ) {
      this.animalService
        .deleteAnimal(id)
        .pipe()
        .subscribe(
          (res) => {
            this.loading = true;
            this.getAnimals();
            this.alertService.success('Animal deletado com sucesso!');
          },
          (err) => {
            this.alertService.danger('Erro ao deletar o animal!');
          }
        );
    }
  }
}
