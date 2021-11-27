import { PorteService } from './../../service/porte.service';
import { Pessoa } from './../../models/pessoa.model';
import { Raca } from './../../models/raca.model';
import { RacaService } from './../../service/raca.service';
import { DoadorService } from './../../service/doador.service';
import { AlertService } from '@full-fledged/alerts';
import { Animal, imagens } from './../../models/animal.model';
import { AnimalService } from './../../service/animal.service';
import { EspecieService } from './../../service/especie.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Especie } from 'src/app/models/especie.model';
import { DOCUMENT } from '@angular/common';
import { Porte } from 'src/app/models/porte.model';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-pet-register',
  templateUrl: './pet-register.component.html',
  styleUrls: ['./pet-register.component.scss'],
})
export class PetRegisterComponent implements OnInit {
  @Input() public editAnimal;
  @Input() public id_doador;
  registerPetForm: FormGroup;
  especies: Especie[] = [];
  raca: Raca[] = [];
  base64ImageString;
  animal: Animal;
  porte: Porte[] = [];
  loading = true;
  constructor(
    @Inject(DOCUMENT) private _document: Document,
    private fb: FormBuilder,
    public activeModal: NgbActiveModal,
    private especieService: EspecieService,
    private animalService: AnimalService,
    private alertService: AlertService,
    private doadorService: DoadorService,
    private racaService: RacaService,
    private porteService: PorteService,
    private _sanitizer: DomSanitizer
  ) {
    this.registerPetForm = this.fb.group({
      nome: ['', Validators.required],
      id_animal: [0],
      id_raca: [0],
      imagens: [''],
      id_doador: [0],
      id_especie: [0],
      id_porte: [0, Validators.required],
    });
  }

  ngOnInit(): void {
    this.getPorte();
    if (this.editAnimal !== undefined) {
      this.refreshForms(this.editAnimal);
      this.racaEditAnimal();
    } else {
      this.getEspecie();
    }
  }
  refreshForms(animal: Animal) {
    Object.keys(this.registerPetForm.controls).forEach((name) => {
      this.registerPetForm.controls[name].setValue(animal[name]);
      if (name === 'id_raca') {
        this.registerPetForm.controls[name].setValue(animal[name]);
        this.getEspecieById(animal.id_raca);
      }
    });
  }
  getEspecie() {
    this.especieService
      .retrieveEspecies()
      .pipe()
      .subscribe(
        (res) => {
          this.especies = res;
          this.loading = false;
        },
        (err) => {
          this.alertService.danger('Erro ao retornar as especies!');
        }
      );
  }

  getPorte() {
    this.porteService
      .retrievePorte()
      .pipe()
      .subscribe(
        (res) => {
          this.porte = res;
        },
        (err) => {
          this.alertService.danger('Erro ao retornar os portes!');
        }
      );
  }
  getEspecieById(idEspecie: number) {
    this.especieService
      .retrieveEspecieById(idEspecie)
      .pipe()
      .subscribe(
        (res) => {
          this.registerPetForm.controls['id_especie'].setValue(res.id_especie);
          this.getEspecie();
          this.getRaca(res.id_especie);
        },
        (err) => {
          this.alertService.danger('Erro ao retornar especie por ID');
        }
      );
  }
  getRaca(especie: any, change?: boolean) {
    this.loading = true;
    especie ? especie : (especie = 0);
    this.racaService
      .retrieveRacaByEspecie(especie.id_especie || especie)
      .pipe()
      .subscribe(
        (res) => {
          this.raca = res;
          this.editAnimal && change
            ? this.registerPetForm.controls['id_raca'].patchValue(this.raca)
            : '';
          this.loading = false;
        },
        (err) => {
          this.alertService.danger('Erro ao retornar as Raças!');
        }
      );
  }

  racaEditAnimal() {}

  convertImage(event: any) {
    var files = event.target.files;
    var file = files[0];

    if (files && file) {
      var reader = new FileReader();

      reader.onload = this._handleReaderLoaded.bind(this);

      reader.readAsBinaryString(file);
    }
  }
  _handleReaderLoaded(readerEvt) {
    var binaryString = readerEvt.target.result;
    this.base64ImageString = btoa(binaryString);
    this.animal?.imagens.push({
      imagem: this.base64ImageString,
    });
  }
  register() {
    this.loading = true;
    const body: Animal = {
      id_doador: this.id_doador,
      imagens: [{ imagem: this.base64ImageString }],
      nome: this.registerPetForm.controls['nome'].value,
      id_porte: this.registerPetForm.controls['id_porte'].value,
      id_raca: this.registerPetForm.controls['id_raca'].value,
    };

    if (this.registerPetForm.valid) {
      this.animalService
        .registerAnimal(body)
        .pipe()
        .subscribe(
          (res) => {
            this.alertService.success('Animal Cadastrado com sucesso!');
            this.loading = false;
            this.activeModal.close();
          },
          (err) => {
            this.alertService.danger(
              'Erro ao registrar o animal, verifique os campos e tente novamente!'
            );
          }
        );
    } else {
      this.alertService.danger('Preencha todos os dados corretamente!');
    }
  }
  editarAnimal() {
    this.loading = true;
    const body: Animal = {
      id_doador: this.editAnimal.id_doador,
      id_animal: this.editAnimal.id_animal,
      imagens: this.editAnimal.imagens ? this.editAnimal.imagens : [],
      nome: this.registerPetForm.controls['nome'].value,
      id_porte: this.registerPetForm.controls['id_porte'].value,
      id_raca: this.registerPetForm.controls['id_raca'].value,
    };

    this.animalService
      .editAnimal(body)
      .pipe()
      .subscribe(
        (res) => {
          this.alertService.success('Animal editado com sucesso!');
          this.loading = false;
          this.activeModal.close(true);
        },
        (err) => {
          this.alertService.danger('Erro ao editar o animal!');
        }
      );
  }
}
