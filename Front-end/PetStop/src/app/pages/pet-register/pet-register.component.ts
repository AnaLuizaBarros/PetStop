import { Animal } from './../../models/animal.model';
import { AnimalService } from './../../service/animal.service';
import { EspecieService } from './../../service/especie.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, Inject, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Especie } from 'src/app/models/especie.model';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-pet-register',
  templateUrl: './pet-register.component.html',
  styleUrls: ['./pet-register.component.scss'],
})
export class PetRegisterComponent implements OnInit {
  registerPetForm: FormGroup;
  especies: Especie[] = [];
  base64ImageString;
  animal: Animal;
  constructor(
    @Inject(DOCUMENT) private _document: Document,
    private fb: FormBuilder,
    public activeModal: NgbActiveModal,
    private especieService: EspecieService,
    private animalService: AnimalService
  ) {
    this.registerPetForm = this.fb.group({
      foto: ['', Validators.required],
      nome: ['', Validators.required],
      especie: ['', Validators.required],
      porte: [''],
    });
  }

  ngOnInit(): void {
    this.getEspecie();
  }

  getEspecie() {
    this.especieService
      .retrieveEspecies()
      .pipe()
      .subscribe((res) => {
        for (let index = 0; index < res.length; index++) {
          this.especies.push(res[index]);
        }
      });
  }

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
  }
  register() {
    if (this.registerPetForm.valid) {
      this.animalService
        .registerAnimal(this.registerPetForm.value)
        .pipe()
        .subscribe((res) => {});
    }
  }
}
